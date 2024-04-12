using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.EntityTypeConfig
{
    public class ProductOrderConfig : BaseEntityConfig<ProductOrder>
    {
        public override void Configure(EntityTypeBuilder<ProductOrder> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Quantity).IsRequired(true);
            //builder.HasOne(x => x.Product)
            //    .WithMany(x => x.ProductOrders)
            //    .HasForeignKey(x => x.Id)
            //    .OnDelete(DeleteBehavior.Restrict);
            //builder.HasOne(x => x.Order)
            //    .WithMany(x => x.ProductOrders)
            //    .HasForeignKey(x => x.Id)
            //    .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}
