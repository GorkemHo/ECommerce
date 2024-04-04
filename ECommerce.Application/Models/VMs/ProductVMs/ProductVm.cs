namespace ECommerce.Application.Models.VMs.ProductVMs
{
    public class ProductVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string? ImagePath { get; set; }
        public int? CategoryId { get; set; }
    }
}
