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
            var cartList = await _cartService.GetCartByUserId(userId);
            var cart = cartList.FirstOrDefault();
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddToProduct(int productId, int quantity)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _cartService.AddToCart(userId, productId, quantity);

            var cartItem = new CartItem
            {
                ProductId = productId,
                Quantity = quantity            
            };

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFromCart(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _cartService.DeleteFromCart(userId, productId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAllFromCart(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _cartService.DeleteFromCart(userId, productId);
            return RedirectToAction(nameof(Index));
        }
    }
}
