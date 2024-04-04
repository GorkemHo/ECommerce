using ECommerce.Application.Models.DTOs.UserDto;
using ECommerce.Application.Services.AppUserService;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize("Admin")]

    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        
        private readonly IAppUserService _userService;

        public UsersController(UserManager<AppUser> userManager,  IAppUserService userService)
        {
            _userManager = userManager;
           
            _userService = userService;
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
        public async Task<IActionResult> Create(RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                await _userService.Register(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
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
                return RedirectToAction(nameof(Index));
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
