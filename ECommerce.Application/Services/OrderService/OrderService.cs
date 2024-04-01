using AutoMapper;
using ECommerce.Application.Models.DTOs.OrderDTOs;
using ECommerce.Application.Models.VMs.OrderVMs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Services.OrderService
{
    public class OrderService : IOrderService
    {
        public readonly IOrderRepo _orderRepo;
        public readonly IMapper _mapper;
        public readonly IAppUserRepo _appUserRepo;

        public OrderService(IOrderRepo orderRepo, IMapper mapper, IAppUserRepo appUserRepo)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
            _appUserRepo = appUserRepo;
        }

        public async Task Create(CreateOrdertDto model)
        {
            var order = _mapper.Map<Order>(model);
            await _orderRepo.CreateAsync(order);
        }

        public async Task<CreateOrdertDto> FİllOrder()
        {
            CreateOrdertDto models = new CreateOrdertDto()
            {
                //User = await _appUserRepo.GetFilteredList(
                //    select: x => new AppUserVm
                //    {
                //        Id= x.Id,
                //        FirstName = x.FirstName,
                //        LastName = x.LastName,
                //    })


            };
            return models;
        }

        public async Task Delete(int Id)
        {
            var order = await _orderRepo.GetDefault(x => x.Id.Equals(Id));

            if (order is not null)
            {
                order.DeleteDate = DateTime.Now;
                order.Status = Status.Passive;
                await _orderRepo.DeleteAsync(order);
            }
        }

        public async Task<OrderDetailVm> GetByDetails(int Id)
        {
            var order = new OrderDetailVm();
           
            return order;
        }

        public Task<UpdateOrdertDto> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderVm>> GetOrder()
        {
            var order = await _orderRepo.GetFilteredList(select: X => new OrderVm
            {
                ID = X.Id,
                UserFirstName = X.User.FirstName,
                UserLastName = X.User.LastName,
                ProductOrders = X.ProductOrders                

            },where: x=> x.Status != Status.Passive,
            orderby: x => x.OrderBy(x=> x.Id),
            include: x => x.Include(x => x.User));

            //SONU YOK

            return order;
        }

        public async Task Update(UpdateOrdertDto model)
        {
            var order = _mapper.Map<Order>(model);
            await _orderRepo.UpdateAsync(order);
        }
    }
}
