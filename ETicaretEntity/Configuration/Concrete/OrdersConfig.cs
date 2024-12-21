using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretEntity.Entities.Concrete;

namespace ETicaretEntity.Configuration.Concrete
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Id anahtar olarak tanımlanır
            builder.HasKey(o => o.Id);

            // UserId ve OrderStatusId Foreign Key olarak tanımlanır
            builder.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            builder.HasOne(o => o.OrderStatus)
                .WithMany(os => os.Orders)
                .HasForeignKey(o => o.OrderStatusId);

            // Diğer alanlar
            builder.Property(o => o.TotalAmount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(o => o.Status).IsRequired().HasMaxLength(20);
            builder.Property(o => o.ShippingAddress).IsRequired().HasMaxLength(250);
            builder.Property(o => o.PaymentMethod).IsRequired().HasMaxLength(50);
        }
    }
}
