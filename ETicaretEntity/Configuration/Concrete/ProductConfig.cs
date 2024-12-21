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
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Id anahtar olarak tanımlanır
            builder.HasKey(p => p.Id);

            // CategoryId Foreign Key olarak tanımlanır
            builder.Property(p => p.CategoryId).IsRequired();

            // Diğer alanlar
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Stock).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();

            // Navigation Properties
            builder.HasMany(p => p.Categories)
                   .WithMany(c => c.Products)
                   .UsingEntity(j => j.ToTable("ProductCategory"));

            builder.HasMany(p => p.ProductImages)
                   .WithOne(pi => pi.Product)
                   .HasForeignKey(pi => pi.ProductId);

            builder.HasMany(p => p.OrderDetails)
                   .WithOne(od => od.Product)
                   .HasForeignKey(od => od.ProductId);
        }
    }
}
