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
    public class SiteSettingConfig : IEntityTypeConfiguration<SiteSetting>
    {
        public void Configure(EntityTypeBuilder<SiteSetting> builder)
        {

            // Primary Key
            builder.HasKey(s => s.SiteSettingId);

            // Key (Zorunlu, Max 100 karakter)
            builder.Property(s => s.Key)
                   .IsRequired()
                   .HasMaxLength(100);

            // Value (Zorunlu, Max 1000 karakter)
            builder.Property(s => s.Value)
                   .IsRequired()
                   .HasMaxLength(1000);

            // Unique Constraint (Key alanı benzersiz olacak)
            builder.HasIndex(s => s.Key)
                   .IsUnique()
                   .HasDatabaseName("IX_SiteSettings_Key");

            // UpdatedDate, varsayılan olarak null ve güncellenebilir olacak şekilde ayarlanır
            builder.Property(e => e.UpdatedDate)
                .IsRequired(false);
        }
    }
}
