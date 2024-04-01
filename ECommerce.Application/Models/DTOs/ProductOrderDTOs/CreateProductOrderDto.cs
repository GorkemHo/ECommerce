﻿using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Models.DTOs.ProductOrderDTOs
{
    public class CreateProductOrderDto
    {
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Ürün Seçilmek zorundadır.")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Sipariş Seçilmek zorundadır.")]
        public int OrderId { get; set; }

        public List<Product>? Products { get; set; }
        public List<Order>? Orders { get; set; }


        public DateTime CreateDate => DateTime.Now;
        public Status Status => Status.Active;
    }
}
