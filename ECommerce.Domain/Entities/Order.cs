using ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Order : IBaseEntity
    {
        public int Id { get; set; }
        //public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }

        public Payment PaymentType { get; set; }              

        public OrderStatus OrderStatus { get; set; }

        public List<ProductOrder> ProductOrders { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }
    }
}
