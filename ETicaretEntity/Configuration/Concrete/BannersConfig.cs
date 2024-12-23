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
    public class BannerConfig : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            
            // Primary Key
            builder.HasKey(b => b.BannerId);

            // Property ayarları
            builder.Property(b => b.BannerId)
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.Title)
                   .IsRequired()
                   .HasMaxLength(100); // Title maksimum 100 karakter

            builder.Property(b => b.ImageUrl)
                   .IsRequired()
                   .HasMaxLength(500); // Image URL maksimum 500 karakter

            builder.Property(b => b.RedirectUrl)
                   .HasMaxLength(500); // Redirect URL opsiyonel ve maksimum 500 karakter

            builder.Property(b => b.IsActive)
                   .HasDefaultValue(true); // Varsayılan olarak aktif

            // Opsiyonel: Veritabanı için ek ayarlar (örneğin: Index)
            builder.HasIndex(b => b.Title)
                   .HasDatabaseName("IX_Banners_Title");

            builder.HasOne(b => b.Category) // İlişki
                    .WithMany(c => c.Banners)
                    .HasForeignKey(b => b.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade); // Kategori silinirse Banner da silinir
        }
    }
}
