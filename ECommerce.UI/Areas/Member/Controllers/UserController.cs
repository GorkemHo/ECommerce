using AutoMapper;
using ECommerce.Application.Models.DTOs.UserDto;
using ECommerce.Application.Services.AppUserService;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Areas.Member.Controllers
{
    [Authorize]
    [Area("Member")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _userService;
        private readonly IMapper _mapper;

        public UserController(UserManager<AppUser> userManager, IMapper mapper, IAppUserService userService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            // Kullanıcı bilgilerini al
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public async Task<IActionResult> Edit()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = _mapper.Map<UpdateProfileDto>(user);
            if (user == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateProfileDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            model.Id = user.Id;

            await _userService.UpdateUser(model);

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }
    }
}
