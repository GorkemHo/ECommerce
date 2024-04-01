using ECommerce.Application.Models.DTOs;
using ECommerce.Application.Models.VMs;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.OrderService
{
    public interface IOrderService
    {
        Task Create(CreateOrdertDto model);

        Task Update(UpdateOrdertDto model);

        Task Delete(int Id);

        Task<List<OrderVM>> GetOrder();

        Task<OrderDetailVM> GetByDetails(int Id);

        Task<UpdateOrdertDto> GetById(int Id);        

        Task<CreateOrdertDto> CreateOrder();               
               
    }
}
