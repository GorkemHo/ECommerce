using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.SeedData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Emit;

namespace ECommerce.Infrastructure.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext() { }

      


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=DESKTOP-16FKK09; Database=ONLY7BlogProjectDB; Uid=sa; Pwd=123;");
            //optionsBuilder.UseSqlServer("Server=DESKTOP-VU62QDF\SQLSERVERMS; Database=ONLY7BlogProjectDB; Uid=sa; Pwd=123;");
            optionsBuilder.UseSqlServer("Server=JUBATUSX; Database=GADIECommerceDb; Uid=sa; Pwd=123;");
            //optionsBuilder.UseSqlServer("Server=G™RKEMH; Database=GADIECommerceDb; Uid=sa; Pwd=123;");
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.SeedCategories();
            builder.SeedProducts();

            base.OnModelCreating(builder);
        }

    }
}
