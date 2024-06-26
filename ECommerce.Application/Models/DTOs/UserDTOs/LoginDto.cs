﻿using ECommerce.Application.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Models.DTOs.UserDto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Kullanıcı adınızı giriniz.")]
        [Display(Name = "Kullanıcı Adı")]
        //[UserNameCheck]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifrenizi giriniz.")]
        [Display(Name = "Kullanıcı Şifresi")]
        [DataType(DataType.Password)]
        //[UserNameCheck]
        public string Password { get; set; }
    }
}
