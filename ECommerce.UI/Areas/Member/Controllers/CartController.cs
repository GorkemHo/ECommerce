using ECommerce.Application.Models.DTOs.OrderDTOs;
using ECommerce.Application.Models.VMs.CartVMs;
using ECommerce.Application.Services.CartService;
using ECommerce.Application.Services.OrderService;
using ECommerce.Domain.Entities;
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


        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        public async Task<IActionResult> Index()
        {
            var cart = await _cartService.GetUserCart();
            return View(cart);
        }

        public async Task<IActionResult> AddItem(int productId, int quantity = 1, int redirect = 0)
        {
            var cartCount = await _cartService.AddItem(productId, quantity);
            
            //TempData["Success"]= "Ürün Sepete Eklendi";
            var cart = await _cartService.GetUserCart();
            return View("Index", cart);
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

        //public async Task<IActionResult> Checkout()
        //{
        //    bool isCheckedOut = await _cartService.DoCheckout();
        //    if (!isCheckedOut)
        //        throw new Exception("Something happen in server side");
        //    return RedirectToAction("Index", "Home");
        //}










    }
}
