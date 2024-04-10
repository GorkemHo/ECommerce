using ECommerce.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Extensions
{
    public class MailAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string email = value as string;

            if (string.IsNullOrEmpty(email))
            {
                return new ValidationResult("E-posta adresi boş olamaz.");
            }

            
            var dbContext = (AppDbContext)validationContext.GetService(typeof(AppDbContext));
            var existingUser = dbContext.Users.FirstOrDefault(u => u.Email == email);

            if (existingUser != null)
            {
                return new ValidationResult("Bu mail ile daha önce kayıt olunmuştur.");
            }

            return ValidationResult.Success;
        }
    }
}
