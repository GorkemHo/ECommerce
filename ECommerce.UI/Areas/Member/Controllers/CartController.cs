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










    }
}
