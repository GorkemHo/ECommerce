using ECommerce.Application.Models.DTOs.UserDto;
using ECommerce.Application.Services.AppUserService;
using ECommerce.Application.Services.CartService;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Policy;

namespace ECommerce.UI.Controllers
{
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private readonly IAppUserService _userService;
        private readonly ICartService _cartService;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(IAppUserService userService, ICartService cartService, UserManager<AppUser> userManager)
        {
            _userService = userService;
            _cartService = cartService;
            _userManager = userManager;
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return View(registerDto);
            }

            var result = await _userService.Register(registerDto);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(registerDto.Email);
                _cartService.CreateCart(user.Id);
            }

            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        public ActionResult Login(string returnUrl = "/")
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto loginDto, string? returnUrl = "/")
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Login(loginDto);
                if (result.Succeeded)
                {
                    if (await _userService.UserInRole(loginDto.UserName, "Admin"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }

                    else if (await _userService.UserInRole(loginDto.UserName, "Member"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Member" });
                    }

                    return RedirectToLocal(returnUrl);
                }
                ModelState.AddModelError("", "Hatalı Giriş İşlemi");
            }
            return View(loginDto);
        }
        private IActionResult RedirectToLocal(string returnUrl = "/")
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            else
                return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _userService.LogOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
