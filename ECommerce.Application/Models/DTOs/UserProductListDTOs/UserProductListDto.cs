using ECommerce.Application.Models.DTOs.OrderDTOs;
using ECommerce.Application.Models.DTOs.UserDto;
using ECommerce.Application.Models.VMs.OrderVMs;
using ECommerce.Application.Models.VMs.ProductOrderVMs;
using ECommerce.Application.Models.VMs.ProductVMs;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Models.DTOs.UserProductListDTOs
{
    public class UserProductListDto
    {
        public List<UpdateProfileDto> AppUsers {  get; set; }
        public List<ProductVm> Products {  get; set; }
        public List<OrderVm> Orders {  get; set; } 
        public CreateOrderDto CreateOrder { get; set; }
    }
}
