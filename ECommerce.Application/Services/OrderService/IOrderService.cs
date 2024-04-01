using ECommerce.Application.Models.DTOs.OrderDTOs;
using ECommerce.Application.Models.VMs.OrderVMs;

namespace ECommerce.Application.Services.OrderService
{
    public interface IOrderService
    {
        Task Create(CreateOrdertDto model);

        Task Update(UpdateOrdertDto model);

        Task Delete(int Id);

        Task<List<OrderVm>> GetOrder();

        Task<OrderDetailVm> GetByDetails(int Id);

        Task<UpdateOrdertDto> GetById(int Id);        

        Task<CreateOrdertDto> FİllOrder();               
               
    }
}
