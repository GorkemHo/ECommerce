using ECommerce.Application.Extensions;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Models.DTOs.CategortyDto
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [PictureFileExtension]
        public IFormFile UploadPath { get; set; }
        public string? ImagePath { get; set; }
        public List<Product>? Products { get; set; }
        public DateTime CreateDate => DateTime.Now;
        public Status Status => Status.Active;
    }
}
