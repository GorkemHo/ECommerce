using ECommerce.Domain.Enums;

namespace ECommerce.Application.Models.VMs.ProductOrderVMs
{
    public class ProductOrderDetailsVm
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        /*public Product Product { get; set; */

        public int OrderId { get; set; }
        //public Order Order { get; set; }


        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }
    }
}

