using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.SeedData
{
    public static class CategorySeedData
    {
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Çok Amaçlı",
                    Description = "Çakmak",
                    CreateDate = DateTime.Now,
                    Status = Status.Active
                },
                new Category
                {
                    Id = 2,
                    Name = "Mumlar İçin",
                    Description = "Çakmak",
                    CreateDate = DateTime.Now,
                    Status = Status.Active
                }               
            );
        }
    }
}
