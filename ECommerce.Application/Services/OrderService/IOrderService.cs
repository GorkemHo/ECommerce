using ECommerce.Application.Models.DTOs.OrderDTOs;
using ECommerce.Application.Models.VMs.OrderVMs;
using ECommerce.Application.Models.VMs.ProductOrderVMs;
using ECommerce.Application.Models.VMs.ProductVMs;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services.OrderService
{
    public interface IOrderService
    {
        Task Create(CreateOrderDto model);

        Task Update(UpdateOrderDto model);

        Task Delete(int Id);

        Task<List<OrderVm>> GetOrder();

        Task<OrderDetailVm> GetByDetails(int Id);

        Task<UpdateOrderDto> GetById(int Id);        

        Task<CreateOrderDto> FillOrder(AppUser appUser, List<ProductOrder> productOrderVm);               
               
    }
}
