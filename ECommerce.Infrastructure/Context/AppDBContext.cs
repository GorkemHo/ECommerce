using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Context
{
    public class AppDBContext : IdentityDbContext
    {
        public AppDBContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=DESKTOP-16FKK09; Database=ECommerceDb; Uid=sa; Pwd=123;");
            //optionsBuilder.UseSqlServer("Server=G™RKEMH; Database=ECommerceDb; Uid=sa; Pwd=123;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);
        }
    }
}
