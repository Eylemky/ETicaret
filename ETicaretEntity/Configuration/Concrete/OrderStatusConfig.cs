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
    public class OrderStatusConfig : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            // Primary Key
            builder.HasKey(os => os.OrderStatusId);

            // StatusName Alanı (Zorunlu, Maksimum 50 Karakter)
            builder.Property(os => os.StatusName)
                   .IsRequired()
                   .HasMaxLength(50);

            // İlişkiler (Orders ile One-to-Many)
            builder.HasMany(os => os.Orders)
                   .WithOne(o => o.OrderStatus)
                   .HasForeignKey(o => o.OrderStatusId)
                   .OnDelete(DeleteBehavior.Restrict); // Cascade yerine Restrict kullanıldı
        }
    }
}
