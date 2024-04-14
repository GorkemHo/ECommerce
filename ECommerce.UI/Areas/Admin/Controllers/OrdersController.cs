using AutoMapper;
using ECommerce.Application.Models.DTOs.OrderDTOs;
using ECommerce.Application.Models.DTOs.UserProductListDTOs;
using ECommerce.Application.Models.VMs.OrderVMs;
using ECommerce.Application.Models.VMs.ProductOrderVMs;
using ECommerce.Application.Services.AppUserService;
using ECommerce.Application.Services.OrderService;
using ECommerce.Application.Services.ProductService;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            UserProductListDto model = new UserProductListDto
            {
                AppUsers = await _appUserService.GetAllUsers(),
                Products = await _productService.GetProducts(),
                Orders = await _orderService.GetOrder(),
                CreateOrder = new CreateOrderDto(),
            };
            return View(model);
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
        public async Task<IActionResult> Create(UserProductListDto model, string userId)
        {
            var listProductOrder = new List<ProductOrder>();

            foreach(var productOrder in model.ProductOrders)
            {
                listProductOrder.Add(productOrder);
            }

            CreateOrderDto order = new CreateOrderDto
            {
                UserId = userId,
                ProductOrders = listProductOrder
            };

            await _orderService.Create(order);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var order = await _orderService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            UserProductListDto model = new UserProductListDto
            {
                AppUsers = await _appUserService.GetAllUsers(),
                Products = await _productService.GetProducts(),
                Orders = await _orderService.GetOrder(),                
                updateOrder = order
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UserProductListDto model)
        {
            if (id != model.updateOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {                
                await _orderService.Update(model.updateOrder);
                return RedirectToAction(nameof(Index));
            }            

            UserProductListDto userProductListDto = new UserProductListDto
            {
                AppUsers = await _appUserService.GetAllUsers(),
                Products = await _productService.GetProducts(),
                Orders = await _orderService.GetOrder(),
                CreateOrder = new CreateOrderDto(),
                updateOrder = await _orderService.GetById(id)
            };

            return View(userProductListDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _orderService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            UserProductListDto model = new UserProductListDto
            {
                AppUsers = await _appUserService.GetAllUsers(),
                Products = await _productService.GetProducts(),
                Orders = await _orderService.GetOrder(),
                updateOrder = order
            };
            return View(model);
        }

        [HttpPost]
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
            UserProductListDto model = new UserProductListDto
            {
                AppUsers = await _appUserService.GetAllUsers(),
                Products = await _productService.GetProducts(),
                Orders = await _orderService.GetOrder(),
                updateOrder = order
            };
            return View(model);
        }
    }
}
