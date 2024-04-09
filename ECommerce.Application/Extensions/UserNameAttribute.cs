using ECommerce.Application.Models.DTOs.UserDto;
using ECommerce.Application.Services.AppUserService;
using ECommerce.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Extensions
{
    public class UserNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string userName = value as string;

            if (string.IsNullOrEmpty(userName))
            {
                return new ValidationResult("Kullanıcı adı boş olamaz.");
            }

            
            string normalizedUserName = userName.ToLower();

            
            var dbContext = (AppDbContext)validationContext.GetService(typeof(AppDbContext));
            var existingUser = dbContext.Users.FirstOrDefault(u => u.NormalizedUserName == normalizedUserName);

            if (existingUser != null)
            {
                return new ValidationResult("Bu kullanıcı adı başka bir kullanıcı tarafından alınmıştır.");
            }

            return ValidationResult.Success;
        }

    }
}

