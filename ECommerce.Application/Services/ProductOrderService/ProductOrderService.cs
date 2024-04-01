using AutoMapper;
using ECommerce.Application.Models.DTOs.ProductOrderDTOs;
using ECommerce.Application.Models.VMs.OrderVMs;
using ECommerce.Application.Models.VMs.ProductOrderVMs;
using ECommerce.Application.Models.VMs.ProductVMs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.ProductOrderService
{
    public class ProductOrderService : IProductOrderService
    {
        private readonly IProductOrderRepo _productOrderRepo;
        private readonly IProductRepo _productRepo;
        private readonly IOrderRepo _orderRepo;
        private readonly IMapper _mapper;

        public ProductOrderService(IProductOrderRepo productOrderRepo, IProductRepo productRepo, IOrderRepo orderRepo, IMapper mapper)
        {
            _productOrderRepo = productOrderRepo;
            _productRepo = productRepo;
            _orderRepo = orderRepo;
            _mapper = mapper;
        }


        public async Task Create(CreateProductOrderDto model)
        {
            var productOrder = _mapper.Map<ProductOrder>(model);

            if (productOrder != null)
            {
                await _productOrderRepo.CreateAsync(productOrder);
            }
        }
        public async Task Update(UpdateProductOrderDto model)
        {
            var productOrder = _mapper.Map<ProductOrder>(model);

            if (productOrder != null)
            {
                await _productOrderRepo.UpdateAsync(productOrder);
            }
        }

        public async Task Delete(int id)
        {
            var model = await _productOrderRepo.GetDefault(x => x.Id.Equals(id));

            if (model != null)
            {
                model.DeleteDate = DateTime.Now;
                model.Status = Status.Passive;
                await _productOrderRepo.UpdateAsync(model);
            }
        }

        public async Task<CreateProductOrderDto> FillProductOrders()
        {
            CreateProductOrderDto model = new CreateProductOrderDto()
            {
                Orders = await _orderRepo.GetFilteredList(
                select: x => new OrderVm
                {
                    ID = x.Id,
                    UserFirstName = x.User.FirstName,
                    UserLastName = x.User.LastName
                },
                where: x => x.Status != Status.Passive
                ),
                Products = await _productRepo.GetFilteredList(
                    select: x => new ProductVm
                    {
                        CategoryId = x.CategoryId,
                        CategoryName = x.Name
                    },
                    where: x => x.Status != Status.Passive)
                      
            };

            return model;
        }

        public async Task<UpdateProductOrderDto> GetById(int id)
        {
            var productOrder = await _productOrderRepo.GetFilteredList(select: x => new ProductOrderVm
            {
                Id = x.Id,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
            }, where: x => x.Id == id);

            var model = _mapper.Map<UpdateProductOrderDto>(productOrder);

            model.Products = await _productRepo.GetFilteredList(select: x => new ProductVm
            {
                Id = x.Id,
                Name = x.Name,
            }, where: x => x.Status != Status.Passive,
            orderby: x => x.OrderBy(x => x.Name));

            model.Orders = await _orderRepo.GetFilteredList(select: x => new OrderVm
            {
                ID = x.Id,
                UserFirstName = x.User.FirstName,
                UserLastName = x.User.LastName
            }, where: x => x.Status != Status.Passive,
            orderby: x => x.OrderBy(x => x.User.FirstName));

            return model;
        }

        public async Task<ProductOrderDetailsVm> GetDetails(int id)
        {
            var productOrder = await _productOrderRepo.GetFilteredFirstOrDefault(select: x => new ProductOrderDetailsVm
            {
                Id = x.Id,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                CreateDate = x.CreateDate,
                UpdateDate = x.UpdateDate,
                Status = x.Status,

            }, where: x => x.Id == id,
            orderby: x => x.OrderBy(x => x.OrderId),
            include: x => x.Include(x => x.Order).Include(x => x.Product));

            return productOrder;
        }

        public async Task<List<ProductOrderVm>> GetProductOrderForUsers()
        {
            var productOrder = await _productOrderRepo.GetFilteredList(select: x => new ProductOrderVm
            {
                Id = x.Id,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                Quantity = x.Quantity,



            }, where: x => x.Status != Status.Passive,
            orderby: x => x.OrderBy(x => x.Id),
            include: x => x.Include(x => x.Order).Include(x => x.Product));

            return productOrder;
        }

        public async Task<List<ProductOrderVm>> GetProductOrders()
        {
            var productOrder = await _productOrderRepo.GetFilteredList(select: x => new ProductOrderVm
            {
                Id = x.Id,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                Quantity = x.Quantity,


            }, where: x => x.Status != Status.Passive,
            orderby: x => x.OrderBy(x => x.Id),
            include: x => x.Include(x => x.Order).Include(x => x.Product));

            return productOrder;
        }


    }
}
