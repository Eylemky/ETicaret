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
    public class ProductImageConfig : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            // Id anahtar olarak tanımlanır
            builder.HasKey(pi => pi.ProductImageId);

            // ProductId Foreign Key olarak tanımlanır
            builder.Property(pi => pi.ProductId).IsRequired();

            // Diğer alanlar
            builder.Property(pi => pi.ImageUrl).IsRequired().HasMaxLength(250);

            // Navigation Property
            builder.HasOne(pi => pi.Product)
                   .WithMany(p => p.ProductImages)
                   .HasForeignKey(pi => pi.ProductId);
        }
    }
}
