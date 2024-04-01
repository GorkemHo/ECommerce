using ECommerce.Application.Extensions;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Models.DTOs.ProductDTOs
{
    public class UpdateProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ürünün adı girilmelidir!")]
        [Display(Name = "Ürün Adı")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Ürün rengi girilmelidir!")]
        [Display(Name = "Ürün Rengi")]
        public string Color { get; set; }


        [Required(ErrorMessage = "Ürün fiyatı girilmelidir!")]
        [Display(Name = "Ürün Fiyatı")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Ürün sayısı girilmelidir!")]
        [Display(Name = "Ürün Sayısı")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Ürün tanımı girilmelidir!")]
        [Display(Name = "Ürün Tanımı")]
        public string Description { get; set; }


        [PictureFileExtension]
        public string? ImagePath { get; set; }
        public IFormFile? UploadPath { get; set; }
        public DateTime UpdateDate => DateTime.Now;

        public Status Status => Status.Modified;

        [Required(ErrorMessage = "Ürüne ait kategori seçilmelidir!")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }


    }
}
