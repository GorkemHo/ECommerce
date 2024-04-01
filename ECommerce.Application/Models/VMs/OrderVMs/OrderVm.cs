using ECommerce.Domain.Entities;

namespace ECommerce.Application.Models.VMs.OrderVMs
{
    public class OrderVm
    {
        public int ID { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserImagePath { get; set; }

        public string UserFullName => $"{UserFirstName} {UserLastName}";

        public int UserId { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }
    }
}
