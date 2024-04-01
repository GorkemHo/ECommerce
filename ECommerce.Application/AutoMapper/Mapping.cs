﻿using AutoMapper;
using ECommerce.Application.Models.DTOs.CategortyDto;
using ECommerce.Application.Models.DTOs.UserDto;
using ECommerce.Application.Models.VMs.CategoryVMs;
using ECommerce.Domain.Entities;
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
            CreateMap<AppUser, RegisterDto>().ReverseMap();
            CreateMap<AppUser, LoginDto>().ReverseMap();
            CreateMap<AppUser, UpdateProfileDto>().ReverseMap();

            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, CategoryVM>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ProductVm>().ReverseMap();
        }
       
    }
}
