using AutoMapper;
using ECommerce.Application.Models.DTOs.OrderDTOs;
using ECommerce.Application.Models.DTOs.UserProductListDTOs;
using ECommerce.Application.Models.VMs.CartVMs;
using ECommerce.Application.Models.VMs.ProductOrderVMs;
using ECommerce.Application.Services.CartService;
using ECommerce.Application.Services.OrderService;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.UI.Areas.Member.Controllers
{
    [Authorize]
    [Area("Member")]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;


        public CartController(ICartService cartService, IOrderService orderService, IMapper mapper)
        {
            _cartService = cartService;
            _orderService = orderService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {

            Cart cart = await _cartService.GetUserCart();


            return View(cart);


        }

        public async Task<IActionResult> AddItem(int productId, int quantity = 1, int redirect = 0, string returnUrl = "/")
        {

            var cartCount = await _cartService.AddItem(productId, quantity);


            var cart = await _cartService.GetUserCart();

            TempData["Success"] = "Sepete ürün eklendi.";



            return Redirect(returnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> OrderCreate([FromForm] string UserId, [FromForm] int productId, [FromForm] int quantity)
        {
            var productOrder = new ProductOrder
            {
                ProductId = productId,
                Quantity = quantity
            };

            CreateOrderDto model = new CreateOrderDto
            {
                UserId = UserId,
                ProductOrders = new List<ProductOrder> { productOrder }
            };

            await _orderService.Create(model);

            return View();
        }

        public async Task<IActionResult> RemoveItem(int productId)
        {
            var cartCount = await _cartService.RemoveItem(productId);
            TempData["Success"] = "Ürün Sepetten Çıkartıldı.";
            return RedirectToAction("Index");
        }
        //public async Task<IActionResult> GetUserCart()
        //{

        //    return RedirectToAction("Index");
        //}


        public async Task<IActionResult> GetTotalItemInCart()
        {
            int cartItem = await _cartService.GetCartItemCount();
            return Ok(cartItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderFromCart(Payment paymentType)
        {

            Cart cart = await _cartService.GetUserCart();
            List<ProductOrder> list = new List<ProductOrder>();
            if (cart.CartItems.Count > 0 && cart.CartItems != null )
            {

                foreach (CartItem cartItem in cart.CartItems)
                {
                    ProductOrder productOrder = new ProductOrder
                    {
                        ProductId = cartItem.ProductId,
                        Quantity = cartItem.Quantity,
                        CreateDate = DateTime.Now,

                    };
                    list.Add(productOrder);


                }
                CreateOrderDto model = new CreateOrderDto
                {
                    UserId = cart.UserId,
                    ProductOrders = list,
                    PaymentType = paymentType

                };


                await _orderService.Create(model);

                CartVm cartVm = _mapper.Map<CartVm>(cart);


                await _cartService.ClearCart();


                return View(cartVm);
            }
            TempData["Danger"] = "Sepetiniz Boş lütfen ürün ekleyiniz.";
            return RedirectToAction("Index");

        }










    }
}
