using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Models.DTOs
{
    public class CreateOrdertDto
    {
        public DateTime CreateDate => DateTime.Now;

        public Status Status => Status.Active;

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public List<ProductOrder> ProductOrders { get; set; }
    }
}
