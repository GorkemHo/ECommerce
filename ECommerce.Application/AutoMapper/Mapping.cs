using AutoMapper;
using ECommerce.Application.Models.DTOs.CategortyDto;
using ECommerce.Application.Models.DTOs.UserDto;
using ECommerce.Application.Models.VMs.CategoryVMs;
using ECommerce.Domain.Entities;
using ECommerce.Application.Models.DTOs.ProductDTOs;
using ECommerce.Application.Models.VMs.ProductVMs;
using ECommerce.Application.Models.VMs.OrderVMs;
using ECommerce.Application.Models.DTOs.OrderDTOs;
using ECommerce.Application.Models.VMs.UserVMs;
using ECommerce.Application.Models.DTOs.ProductOrderDTOs;
using ECommerce.Application.Models.VMs.ProductOrderVMs;
using ECommerce.Application.Models.VMs.CartVMs;

namespace ECommerce.Application.AutoMapper
{
    public class Mapping:Profile
    {
        public Mapping() 
        {
            CreateMap<AppUser, RegisterDto>().ReverseMap();
            CreateMap<AppUser, LoginDto>().ReverseMap();
            CreateMap<AppUser, UpdateProfileDto>().ReverseMap();
            CreateMap<AppUser, AppUserVm>().ReverseMap();

            CreateMap<Category, CreateOrderDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, CategoryVm>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ProductVm>().ReverseMap();

            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();
            CreateMap<Order, OrderVm>().ReverseMap();
            CreateMap<Order, OrderDetailVm>().ReverseMap();

            CreateMap<ProductOrder, CreateProductOrderDto>().ReverseMap();
            CreateMap<ProductOrder, UpdateProductOrderDto>().ReverseMap();
            CreateMap<ProductOrder, ProductOrderVm>().ReverseMap();
            CreateMap<ProductOrder, ProductOrderDetailsVm>().ReverseMap();


            CreateMap<Cart, CartVM>().ReverseMap();
            CreateMap<CartItem, CartItemVm>().ReverseMap();

        }
    }
}
