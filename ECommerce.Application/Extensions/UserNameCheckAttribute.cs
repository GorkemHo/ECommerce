using ECommerce.Application.Models.DTOs.UserDto;
using ECommerce.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Extensions
{
    public class UserNameCheckAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string userName = value as string;

            if (string.IsNullOrEmpty(userName))
            {
                return new ValidationResult("Kullanıcı adı boş olamaz.");
            }

            string normalizedUserName = userName.ToUpper();

            var dbContext = (AppDbContext)validationContext.GetService(typeof(AppDbContext));
            var existingUser = dbContext.Users.FirstOrDefault(u => u.NormalizedUserName == normalizedUserName);

            if (existingUser == null)
            {
                return new ValidationResult("Geçerli bir kullanıcı adı ya da şifre giriniz.");
            }

            var loginDto = new LoginDto();
            if (loginDto != null && !VerifyPassword(existingUser.PasswordHash, loginDto.Password))
            {
                return new ValidationResult("Geçerli bir kullanıcı adı ya da şifre giriniz.");
            }

            return ValidationResult.Success;
        }

        private bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            return hashedPassword == providedPassword;
        }
    }
}

