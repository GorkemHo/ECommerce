using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Models.VMs.OrderVMs
{
    public class OrderDetailVm
    {
        public DateTime CreateDate { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserImagePath { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }
        public Payment PaymentType { get; set; }
    }
}
