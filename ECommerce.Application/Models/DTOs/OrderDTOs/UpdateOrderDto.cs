using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Models.DTOs.OrderDTOs
{
    public class UpdateOrderDto
    {
        public int Id { get; set; }
        public DateTime UpdateDate => DateTime.Now;

        public Status Status => Status.Modified;

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public List<ProductOrder> ProductOrders { get; set; }
    }
}
