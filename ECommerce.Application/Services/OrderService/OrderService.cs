using AutoMapper;
using ECommerce.Application.Models.DTOs.OrderDTOs;
using ECommerce.Application.Models.VMs.OrderVMs;
using ECommerce.Application.Models.VMs.ProductOrderVMs;
using ECommerce.Application.Models.VMs.ProductVMs;
using ECommerce.Application.Models.VMs.UserVMs;
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

        public async Task Create(CreateOrderDto model)
        {
            var order = _mapper.Map<Order>(model);
            await _orderRepo.CreateAsync(order);
        }

        public async Task<CreateOrderDto> FillOrder(AppUser appUser, List<ProductOrder> productOrderVm)
        {
            CreateOrderDto models = new CreateOrderDto()
            {
                User = appUser,
                ProductOrders = productOrderVm
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
                order.OrderStatus = OrderStatus.Cancelled;
                await _orderRepo.DeleteAsync(order);
            }
        }

        public async Task<OrderDetailVm> GetByDetails(int Id)
        {
            var order = await _orderRepo.GetFilteredFirstOrDefault(select: X => new OrderDetailVm
            {
                CreateDate = DateTime.Now,
                UserFirstName = X.User.FirstName,
                UserLastName = X.User.LastName,
                UserImagePath = X.User.ImagePath,
                OrderStatus = X.OrderStatus
            }, where: x => x.Id == Id,
            orderby: x => x.OrderBy(x => x.User.FirstName),
            include: x => x.Include(x => x.User));

            return order;
        }

        public async Task<UpdateOrderDto> GetById(int Id)
        {
            var order = await _orderRepo.GetFilteredFirstOrDefault(select: x => new OrderVm 
            {
            ID = Id,
            OrderStatus =x.OrderStatus,
            UserId = x.UserId,
            ProductOrders = x.ProductOrders,            
            }
            ,where: x => x.Id ==Id);           
            var model = _mapper.Map<UpdateOrderDto>(order);

            model.User = await _appUserRepo.GetFilteredFirstOrDefault(select: x=> new AppUser
            {
                Id= x.Id,
                UserName = x.UserName,
                FirstName = x.FirstName,
                LastName = x.LastName,   
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address,
            },where: x=> x.Id == model.UserId);
            
            return model;
        }

        public async Task<List<OrderVm>> GetOrder()
        {
            var order = await _orderRepo.GetFilteredList(select: X => new OrderVm
            {
                ID = X.Id,
                UserFirstName = X.User.FirstName,
                UserLastName = X.User.LastName,
                ProductOrders = X.ProductOrders,
                OrderStatus = X.OrderStatus
            }, where: x => x.Status != Status.Passive,
            orderby: x => x.OrderBy(x => x.Id),
            include: x => x.Include(x => x.User));

            return order;
        }

        public async Task Update(UpdateOrderDto model)
        {
            var order = _mapper.Map<Order>(model);
            await _orderRepo.UpdateAsync(order);
        }
    }
}
