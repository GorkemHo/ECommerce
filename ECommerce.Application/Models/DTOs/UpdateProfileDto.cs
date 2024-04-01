﻿using ECommerce.Application.Extensions;
using ECommerce.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Models.DTOs
{
    public class UpdateProfileDto
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Kullanıcı adınızı giriniz.")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifrenizi giriniz.")]
        [Display(Name = "Kullanıcı Şifresi")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrarı girilmesi zorunludur.")]
        [Display(Name = "Kullanıcı Şifresi Tekrar")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Şifreler birbirlerine eşit olmalıdır.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email adresi girişi zorunludur.")]
        [Display(Name = "E-Posta")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Resim Dosyası")]
        public string? ImagePath { get; set; }

        [PictureFileExtension]
        public IFormFile UploadPath { get; set; }
        public DateTime UpdateDate => DateTime.Now;
        public Status Status => Status.Modified;
    }
}
