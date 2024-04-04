using ECommerce.Application.Models.VMs.CartVMs;
using ECommerce.Application.Services.CartService;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.UI.Areas.Member.Controllers
{
    [Area("Member")]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private UserManager<AppUser> _userManager;
        public CartController(ICartService cartService, UserManager<AppUser> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartItems = await _cartService.GetCartItemsByUserId(userId);
            return View(cartItems);
        }

        [HttpPost]
        public async Task<IActionResult> AddToProduct(int productId, int quantity)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartItem = new CartItem { ProductId = productId, Quantity = quantity };
            await _cartService.AddToCart(userId, cartItem);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFromCart(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartItem = new CartItemVm
            {
                ProductId = productId,
                
            };
            await _cartService.DeleteFromCart(userId, cartItem);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAllFromCart(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _cartService.ClearToCart(userId);
            return RedirectToAction(nameof(Index));
        }
    }
}
