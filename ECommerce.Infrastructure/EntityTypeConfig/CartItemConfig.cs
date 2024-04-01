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
    public class CartItemConfig : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Quantity).IsRequired(true);
            builder.HasOne(x=> x.Cart)
                .WithMany(x=>x.CartItems)
                .HasForeignKey(x=>x.Id)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
