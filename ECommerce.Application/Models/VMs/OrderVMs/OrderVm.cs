using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;

namespace ECommerce.Application.Models.VMs.OrderVMs
{
    public class OrderVm
    {
        public int ID { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserImagePath { get; set; }

        public OrderStatus OrderStatus { get; set; }
        public string UserFullName => $"{UserFirstName} {UserLastName}";
        public string UserId { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }
    }
}
