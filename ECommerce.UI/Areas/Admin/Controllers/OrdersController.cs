using AutoMapper;
using ECommerce.Application.Models.DTOs.OrderDTOs;
using ECommerce.Application.Models.DTOs.UserProductListDTOs;
using ECommerce.Application.Models.VMs.ProductOrderVMs;
using ECommerce.Application.Services.AppUserService;
using ECommerce.Application.Services.OrderService;
using ECommerce.Application.Services.ProductService;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using CreateOrderDto = ECommerce.Application.Models.DTOs.OrderDTOs.CreateOrderDto;

namespace ECommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrdersController : Controller
    {
        public readonly IOrderService _orderService;
        public readonly IAppUserService _appUserService;
        public readonly IMapper _mapper; 
        public readonly IProductService _productService;

        public OrdersController(IOrderService orderService, IAppUserService appUserService, IMapper mapper, IProductService productService)
        {
            _orderService = orderService;
            _appUserService = appUserService;
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var orderList = await _orderService.GetOrder();
            return View(orderList);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            UserProductListDto model = new UserProductListDto
            {
                AppUsers = await _appUserService.GetAllUsers(),
                Products = await _productService.GetProducts(),
                CreateOrder = new CreateOrderDto(),
           };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] string UserId, [FromForm] int productId, [FromForm] int quantity)
        {
            var productOrder = new ProductOrder
            {
                ProductId = productId,
                Quantity = quantity
            };

            CreateOrderDto model = new CreateOrderDto
            {
                UserId = UserId,
                ProductOrders = new List<ProductOrder> { productOrder }
            };

            await _orderService.Create(model);
            
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _orderService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateOrderDto model)
        {
            if (ModelState.IsValid)
            {
                model.Id = id;
                await _orderService.Update(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _orderService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _orderService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var order = await _orderService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
    }
}
