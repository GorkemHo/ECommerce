﻿using ECommerce.Application.Extensions;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Application.Models.DTOs.ProductDTOs
{
    public class CreateProductDto
    {
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
        public IFormFile? UploadPath { get; set; }
        public DateTime CreateDate => DateTime.Now;
        public Status Status => Status.Active;



        [Required(ErrorMessage = "Ürüne ait kategori seçilmelidir!")]
        public int CategoryId { get; set; }

        public List<Category>? Categories { get; set; }


    }
}
