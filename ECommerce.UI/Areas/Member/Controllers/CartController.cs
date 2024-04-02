using ECommerce.Application.Services.OrderService;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Areas.Member.Controllers
{
    public class CartController : Controller
    {
        private IOrderService _orderService;
        private UserManager<AppUser> _userManager;
        public CartController(IOrderService orderService, UserManager<AppUser> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
