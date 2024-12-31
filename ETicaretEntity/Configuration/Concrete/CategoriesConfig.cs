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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Id anahtar olarak tanımlanır
            builder.HasKey(c => c.CategoryId);

            // Diğer alanlar
            builder.Property(c => c.CategoryName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(500);

            // Navigation Property
            builder.HasMany(c => c.Products)
                   .WithMany(p => p.Categories)
                   .UsingEntity(j => j.ToTable("ProductCategory"));
        }
    }
}
