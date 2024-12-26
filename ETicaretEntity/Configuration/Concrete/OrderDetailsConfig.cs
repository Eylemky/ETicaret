using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretEntity.Entities.Concrete;
using ETicaret.Entities.Configuration.Abstract;

namespace ETicaretEntity.Configuration.Concrete
{
    public class OrderDetailsConfig : BaseConfig<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            // Id anahtar olarak tanımlanır
            builder.HasKey(od => od.OrderDetailId);

            // OrderId ve ProductId Foreign Key olarak tanımlanır
            builder.HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            builder.HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductId);

            // Diğer alanlar
            builder.Property(od => od.Quantity).IsRequired();
            builder.Property(od => od.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
        }
    }
}
