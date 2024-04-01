using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Models.VMs
{
    public class OrderVM
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
