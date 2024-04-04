using ECommerce.Application.Models.VMs.ProductVMs;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Models.VMs.CartVMs
{
    public class CartItemVm
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public ProductVm Product { get; set; }
        public decimal TotalPrice()
        {
            return Price * Quantity;
        }
    }
}
