using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
