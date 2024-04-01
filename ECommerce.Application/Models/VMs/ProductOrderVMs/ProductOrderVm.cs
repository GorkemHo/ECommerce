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
