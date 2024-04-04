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
    public static class ProductSeedData
    {
        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "çakmak 1",
                    Color = "Kırmızı",
                    Price = 100,
                    Quantity = 10,
                    Description = "Bu ürünün açıklaması 1",
                    ImagePath = "../../images/00285a53-201b-475e-b056-31b524c0354c.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "çakmak 2",
                    Color = "Mavi",
                    Price = 150,
                    Quantity = 5,
                    Description = "Bu ürünün açıklaması 2",
                    ImagePath = "../../images/00ca64ae-faaa-4235-bd98-a4bb4623bfc2.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 3,
                    Name = "çakmak 3",
                    Color = "Yeşil",
                    Price = 200,
                    Quantity = 8,
                    Description = "Bu ürünün açıklaması 3",
                    ImagePath = "images/cakmak3.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 4,
                    Name = "çakmak 4",
                    Color = "Sarı",
                    Price = 120,
                    Quantity = 12,
                    Description = "Bu ürünün açıklaması 4",
                    ImagePath = "images/cakmak4.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 5,
                    Name = "çakmak 5",
                    Color = "Mor",
                    Price = 180,
                    Quantity = 6,
                    Description = "Bu ürünün açıklaması 5",
                    ImagePath = "images/cakmak5.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 6,
                    Name = "Cüzdan 1",
                    Color = "Mavi",
                    Price = 150,
                    Quantity = 5,
                    Description = "Bu ürünün açıklaması 1",
                    ImagePath = "images/Aksesuar1.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 7,
                    Name = "Cüzdan 2",
                    Color = "Kırmızı",
                    Price = 150,
                    Quantity = 5,
                    Description = "Bu ürünün açıklaması 2",
                    ImagePath = "images/Aksesuar2.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 8,
                    Name = "Gözlük 1",
                    Color = "Kırmızı",
                    Price = 150,
                    Quantity = 5,
                    Description = "Bu ürünün açıklaması 2",
                    ImagePath = "images/Aksesuar2.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 4
                },
                new Product
                {
                    Id = 9,
                    Name = "Gözlük 2",
                    Color = "Kırmızı",
                    Price = 150,
                    Quantity = 5,
                    Description = "Bu ürünün açıklaması 2",
                    ImagePath = "images/Aksesuar2.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 4
                },
                new Product
                {
                    Id = 10,
                    Name = "Kalem 1",
                    Color = "Kırmızı",
                    Price = 150,
                    Quantity = 5,
                    Description = "Bu ürünün açıklaması 2",
                    ImagePath = "images/Aksesuar2.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 5
                },
                new Product
                {
                    Id = 11,
                    Name = "Kaelm 2",
                    Color = "Kırmızı",
                    Price = 150,
                    Quantity = 5,
                    Description = "Bu ürünün açıklaması 2",
                    ImagePath = "images/Aksesuar2.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 5
                }
            );
        }
    }
}
