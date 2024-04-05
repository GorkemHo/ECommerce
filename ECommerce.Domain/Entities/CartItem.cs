using ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    [Table("CartDetail")]
    public class CartItem
    {
        //public int Id { get; set; }

        //public int Quantity { get; set; }
        //public decimal Price { get; set; }
        //public string ProductName { get; set; }

        //public int ProductId { get; set; }
        //public Product Product { get; set; }

        //public int CartId { get; set; }
        //public Cart Cart { get; set; }

        public int Id { get; set; }
        [Required]
        public int ShoppingCartId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        public Product Product { get; set; }
        public Cart ShoppingCart { get; set; }
    }
}
