using ECommerce.Application.Models.DTOs.UserDto;
using ECommerce.Application.Services.AppUserService;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAppUserService _userService;
        private readonly SignInManager<AppUser> _signInManager;


        public UsersController(UserManager<AppUser> userManager, IAppUserService userService, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _userService = userService;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            var userList = await _userService.GetAllUsers();

            return View(userList);
        }

        public async Task<IActionResult> Details(string id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return View(registerDto);
            }


            var result = await _userService.CreateUserByAdmin(registerDto);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(registerDto.Email);


                if (user != null)
                {
                    if (registerDto.UserName == "Admin")
                    {
                        TempData["Warning"] = "Admin kullanıcı adı ile kayıt olamazsınız!";
                        return View();

                    }

                    if (registerDto.UserName != "Admin")
                    {
                        if (!await _roleManager.RoleExistsAsync("Member"))
                        {
                            await _roleManager.CreateAsync(new IdentityRole("Member"));
                        }

                        await _userManager.AddToRoleAsync(user, "Member");



                        TempData["Success"] = "Kullanıcı Kaydı Gerçekleştirildi.";


                        return RedirectToAction("Index", "Users");

                    }


                }

                return RedirectToAction("Index", "Users");

            }
            else
            {
                TempData["Warning"] = "Admin kullanıcı adı ile kayıt olamazsınız!";

                return View();
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, UpdateProfileDto model)
        {
            if (ModelState.IsValid)
            {
                model.Id = id;
                await _userService.UpdateUser(model);
                TempData["Success"] = "Güncelleme Başarılı";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _userService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }


}
