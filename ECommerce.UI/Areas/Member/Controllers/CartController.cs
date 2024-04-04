using ECommerce.Application.Models.VMs.CartVMs;
using ECommerce.Application.Services.CartService;
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

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        public async Task<IActionResult> AddItem(int bookId, int quantity = 1, int redirect = 0)
        {
            var cartCount = await _cartService.AddItem(bookId, quantity);
            //if (redirect == 0)
            //    return Ok(cartCount);
            return RedirectToAction("GetUserCart");
        }

        public async Task<IActionResult> RemoveItem(int bookId)
        {
            var cartCount = await _cartService.RemoveItem(bookId);
            return RedirectToAction("GetUserCart");
        }
        public async Task<IActionResult> GetUserCart()
        {
            
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Index()
        {
            var cart = await _cartService.GetUserCart();
            return View(cart);
        }

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










        //private readonly ICartService _cartService;
        //private UserManager<AppUser> _userManager;
        //public CartController(ICartService cartService, UserManager<AppUser> userManager)
        //{
        //    _cartService = cartService;
        //    _userManager = userManager;
        //}
        //public async Task<IActionResult> Index()
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var cart = await _cartService.GetCart(userId);

        //    return View(cart);
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddToProduct(int productId, int quantity)
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


        //    var cartItem = new CartItem
        //    {
        //        ProductId = productId,
        //        Quantity = quantity            
        //    };

        //    await _cartService.AddToCart(userId,cartItem); //???

        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpPost]
        //public async Task<IActionResult> DeleteFromCart(int productId)
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    var cartItem = new CartItemVm
        //    {
        //        ProductId = productId,

        //    };

        //    await _cartService.DeleteFromCart(userId, cartItem);
        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpPost]
        //public async Task<IActionResult> DeleteAllFromCart(int productId)
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    await _cartService.ClearToCart(userId);

        //    return RedirectToAction(nameof(Index));
        //}
    }
}
