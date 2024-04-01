using AutoMapper;
using ECommerce.Application.Models.DTOs.ProductOrderDTOs;
using ECommerce.Application.Models.VMs.ProductOrderVMs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Repositories;
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
                //  Orders = await _orderRepo.GetFilteredList(
                //select: new OrderV
                //      )
            };

            return model;
        }

        public Task<UpdateProductOrderDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductOrderDetailsVm> GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductOrderVm>> GetProductOrderForUsers()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductOrderVm>> GetProductOrders()
        {
            throw new NotImplementedException();
        }


    }
}
