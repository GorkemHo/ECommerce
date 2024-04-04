using ECommerce.Application.Models.VMs.ProductVMs;
using ECommerce.Application.Services.CategoryService;
using ECommerce.Application.Services.ProductService;
using ECommerce.Domain.Entities;
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
        public async Task<IActionResult> ProductDetail(int Id)
        {
            var product = await _productService.GetById(Id);
            return View(product);
        }
        public async Task<IActionResult> LighterForGeneralPurpose()
        {
            var product = await _productService.GetProducts();
            var model = product.Where(x => x.CategoryName == "Çok Amaçlı").ToList();
            return View(model);
        }
        public async Task<IActionResult> LighterForCandle()
        {
            var product = await _productService.GetProducts();
            var model = product.Where(x => x.CategoryName == "Mumlar İçin").ToList();
            return View(model);
        }
        public async Task<IActionResult> Glasses()
        {
            var product = await _productService.GetProducts();
            var model = product.Where(x => x.CategoryName == "Gözlük").ToList();
            return View(model);
        }
        public async Task<IActionResult> Wallet()
        {
            var product = await _productService.GetProducts();
            var model = product.Where(x => x.CategoryName == "Cüzdan").ToList();
            return View(model);
        }
        public async Task<IActionResult> Pen()
        {
            var product = await _productService.GetProducts();
            var model = product.Where(x => x.CategoryName == "Kalem").ToList();
            return View(model);
        }
        public async Task<IActionResult> AllProducts(string searchTerm, string color, decimal? minPrice, decimal? maxPrice, string CategoryName)
        {
            var product = await _productService.SearchProducts(searchTerm, color, minPrice, maxPrice, CategoryName);
            return View(product);
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
