using ECommerce.Application.Models.DTOs.ProductOrderDTOs;
using ECommerce.Application.Models.VMs.ProductOrderVMs;

namespace ECommerce.Application.Services.ProductOrderService
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
