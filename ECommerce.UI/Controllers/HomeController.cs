using ECommerce.Application.Models.VMs.ProductVMs;
using ECommerce.Application.Services.CategoryService;
using ECommerce.Application.Services.ProductService;
using ECommerce.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ECommerce.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, ICategoryService categoryService)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult ProductDetail(int Id)
        {
            var product =_productService.GetById(Id);
            return View(product);
        }
        public async Task<IActionResult> LighterForGeneralPurpose()
        {
            var category = await _categoryService.GetCategories();
            category.Select(x => "category ismi");            
            
            return View(category);
        }
        public async Task<IActionResult> LighterForCandle()
        {
            var category = await _categoryService.GetCategories();
            category.Select(x => "category ismi");

            return View(category);
        }
        public IActionResult Accessorize()
        {
            return View();
        }
        public IActionResult AllProducts()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
