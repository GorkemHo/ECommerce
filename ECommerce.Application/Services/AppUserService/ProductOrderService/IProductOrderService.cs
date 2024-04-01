using ECommerce.Application.Models.DTOs.ProductOrderDTOs;
using ECommerce.Application.Models.VMs.ProductOrderVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.AppUserService.ProductOrderService
{
    public interface IProductOrderService
    {
        Task Create(CreateProductOrderDto model);
        Task Update(UpdateProductOrderDto model);
        Task Delete(int id);
        Task<List<ProductOrderVm>> GetProductOrders();
        Task<ProductOrderDetailsVm> GetDetails(int id);
        Task<UpdateProductOrderDto> GetById(int id);
        Task<List<ProductOrderVm>> GetProductOrderForUsers();
        Task<CreateProductOrderDto> FillProductOrders();
    }
}
