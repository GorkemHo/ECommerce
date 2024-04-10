using ECommerce.Application.Models.DTOs.MessageDTOs;
using ECommerce.Application.Models.DTOs.UserProductListDTOs;
using ECommerce.Application.Models.VMs.ProductVMs;
using ECommerce.Application.Services.CategoryService;
using ECommerce.Application.Services.MessageService;
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
        private readonly IMessageService _messageService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, ICategoryService categoryService, IMessageService messageService)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
            _messageService = messageService;
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
        //public async Task<IActionResult> LighterForGeneralPurpose(string searchTerm, string color, decimal? minPrice, decimal? maxPrice, string CategoryName)
        //{
        //    var products = await _productService.SearchProducts(searchTerm, color, minPrice, maxPrice, "Çok Amaçlı");
        //    return View(products);
        //}
        //public async Task<IActionResult> LighterForCandle(string searchTerm, string color, decimal? minPrice, decimal? maxPrice, string CategoryName)
        //{
        //    var products = await _productService.SearchProducts(searchTerm, color, minPrice, maxPrice, "Mumlar İçin");
        //    return View(products);
        //}
        //public async Task<IActionResult> Glasses(string searchTerm, string color, decimal? minPrice, decimal? maxPrice)
        //{
        //    var products = await _productService.SearchProducts(searchTerm, color, minPrice, maxPrice, "Gözlük");
        //    return View(products);
        //}
        //public async Task<IActionResult> Wallet(string searchTerm, string color, decimal? minPrice, decimal? maxPrice, string CategoryName)
        //{
        //    var products = await _productService.SearchProducts(searchTerm, color, minPrice, maxPrice, "Cüzdan");
        //    return View(products);
        //}
        //public async Task<IActionResult> AllProducts(string searchTerm, string color, decimal? minPrice, decimal? maxPrice, string CategoryName)
        //{
        //    var product = await _productService.SearchProducts(searchTerm, color, minPrice, maxPrice, CategoryName);
        //    return View(product);
        //}
        public async Task<IActionResult> Pen(string searchTerm, string color, decimal? minPrice, decimal? maxPrice, string CategoryName)
        {
            var products = await _productService.SearchProducts(searchTerm, color, minPrice, maxPrice, CategoryName);
            UserProductListDto userProductListDto = new UserProductListDto
            {
                Products = products,
                CategoryName = CategoryName
            };
            return View(userProductListDto);
        }
        

        public async Task<IActionResult> SearchProduct(string searchTerm, string color, decimal? minPrice, decimal? maxPrice, string CategoryName)
        {
            var product = await _productService.SearchProducts(searchTerm, color, minPrice, maxPrice, CategoryName);
            var categorylist = await _categoryService.GetCategories();
            UserProductListDto userProductListDto = new UserProductListDto
            {
                categoryVms = categorylist,
                Products = product,
            };
            return View(userProductListDto);
        }

        public IActionResult Contact(CreateMessageDto model= null)
        {
            if(model == null)
            {
                model = new CreateMessageDto();
                
            }
            
            return View(model);
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

        [HttpPost]
        public async Task<IActionResult> AddMessage(CreateMessageDto model)
        {
            //await _messageService.Create(model);
            //TempData["Success"] = "Mesajınız Başarıyla iletildi.";
            //return RedirectToAction("Contact", "Home");

            if (ModelState.IsValid)
            {
                await _messageService.Create(model);
                TempData["Success"] = "Mesajınız Başarıyla iletildi.";
                return RedirectToAction("Contact", "Home");
            }
            TempData["Warning"] = "Lütfen Eksik Alan Bırakmayınız.";
            return RedirectToAction("Contact", model);
        }
    }
}
