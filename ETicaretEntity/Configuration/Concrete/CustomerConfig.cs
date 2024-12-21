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
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            

            // Primary Key
            builder.HasKey(c => c.CustomerId);

            // Kolon Özellikleri
            builder.Property(c => c.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(c => c.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(c => c.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.PhoneNumber)
                   .IsRequired(false)
                   .HasMaxLength(15);

            // Navigation Property - One-to-Many Relationship (Customer -> Addresses)
            builder.HasMany(c => c.Addresses)
                   .WithOne(a => a.Customer)
                   .HasForeignKey(a => a.CustomerId);
        }
    }
}
