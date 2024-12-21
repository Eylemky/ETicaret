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
    public class LogConfig : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
           
            // Primary Key
            builder.HasKey(l => l.Id); // BaseEntity'den geliyor

            // LogType
            builder.Property(l => l.LogType)
                   .IsRequired()
                   .HasMaxLength(50); // Maksimum 50 karakter (Error, Info, Warning gibi)

            // Message
            builder.Property(l => l.Message)
                   .IsRequired()
                   .HasMaxLength(500); // Maksimum 500 karakter

            // Details
            builder.Property(l => l.Details)
                   .HasColumnType("nvarchar(max)"); // Büyük detay alanı için uygun

            // BaseEntity'deki CreatedDate için özel ayar
            builder.Property(l => l.CreatedDate)
                   .HasDefaultValueSql("GETDATE()"); // Varsayılan olarak sistem tarihini kullanır

            // BaseEntity'deki UpdatedDate için özel ayar
            builder.Property(l => l.UpdatedDate)
                   .HasDefaultValueSql("GETDATE()"); // Varsayılan olarak sistem tarihini kullanır

            // Index
            builder.HasIndex(l => l.LogType)
                   .HasDatabaseName("IX_Logs_LogType");
        }
    }
}
