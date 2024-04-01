using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Models.VMs.ProductOrderVMs
{
    public class ProductOrderVm
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }       
        public int OrderId { get; set; }
       
    }
}
