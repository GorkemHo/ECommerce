using AutoMapper;
using ECommerce.Application.Models.DTOs.ProductDTOs;
using ECommerce.Application.Models.VMs.ProductVMs;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.AutoMapper
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ProductVm>().ReverseMap();

        }
    }
}
