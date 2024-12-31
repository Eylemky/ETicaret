
using ETicaretEntity.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretEntity.Configuration.Concrete
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            
            // Primary Key
            builder.HasKey(a => a.AddressId);

            // Property ayarları
            builder.Property(a => a.AddressId).ValueGeneratedOnAdd();
            builder.Property(a => a.AddressLine).IsRequired().HasMaxLength(200);
            builder.Property(a => a.City).IsRequired().HasMaxLength(50);
            builder.Property(a => a.State).HasMaxLength(50);

            // Foreign Key
            builder.HasOne(a => a.User)
                   .WithMany(c => c.Addresses)
                   .HasForeignKey(a => a.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

