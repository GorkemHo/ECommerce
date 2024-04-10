using ECommerce.Application.Extensions;
using ECommerce.Application.Models.DTOs.UserDto;
using ECommerce.Application.Services.AppUserService;
using ECommerce.Application.Services.CartService;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(IAppUserService userService, ICartService cartService, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userService = userService;
            _cartService = cartService;
            _userManager = userManager;
            _roleManager = roleManager;
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

                if (user != null)
                {

                    if (registerDto.UserName == "Admin")
                    {
                        if (!await _roleManager.RoleExistsAsync("Admin"))
                        {
                            await _roleManager.CreateAsync(new IdentityRole("Admin"));
                        }

                        await _userManager.AddToRoleAsync(user, "Admin");
                        return RedirectToAction("Login", "Account"); 
                    }
                    if (registerDto.UserName != "Admin")
                    {
                        if (!await _roleManager.RoleExistsAsync("Member"))
                        {
                            await _roleManager.CreateAsync(new IdentityRole("Member"));
                        }

                        await _userManager.AddToRoleAsync(user, "Member");
                        return RedirectToAction("Login", "Account");
                    }


                    _cartService.GetCart(user.Id); 
                }

                return RedirectToAction("Index", "Home"); 
            }
            else
                return View(registerDto);
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
                        return RedirectToAction("Index", "Base", new { area = "Admin" });
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
