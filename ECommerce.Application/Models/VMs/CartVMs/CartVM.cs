using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Models.VMs.CartVMs
{
    public class CartVM
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<CartItemVm> CartItems { get; set; }
        public decimal TotalPrice()
        {
            return CartItems.Sum(i => i.Price * i.Quantity);
        }
    }
}
