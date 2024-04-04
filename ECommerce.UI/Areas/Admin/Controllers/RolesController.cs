using ECommerce.Application.Models.VMs.RoleVMs;
using ECommerce.Application.Services.AppUserService;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize("Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var roleList =_roleManager.Roles.ToList() ;
            return View(roleList);
        }

        public IActionResult UserRoleList()
        {
            var usersRoles = _userManager.Users.ToList();
            return View(usersRoles);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(string id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();

            TempData["UserId"] = user.Id;

            var userRoles = await _userManager.GetRolesAsync(user);

            List<RoleAssignVm> model = new List<RoleAssignVm>();
            foreach (var role in roles)
            {
                RoleAssignVm vm = new RoleAssignVm();
                vm.RoleId = role.Id;
                vm.Name = role.Name;
                vm.Exists = userRoles.Contains(role.Name);
                model.Add(vm);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignVm> model)
        {
            var userid = TempData["UserId"].ToString();
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
            
            foreach(var item in model)
            {
                if (item.Exists)
                {
                    await _userManager.AddToRoleAsync(user, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);
                }
            }

           
            return RedirectToAction("UserRoleList");
        }


    }
}
