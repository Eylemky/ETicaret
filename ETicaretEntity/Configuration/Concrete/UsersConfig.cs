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
    public class UsersConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Id anahtar olarak tanımlanır
            builder.HasKey(u => u.Id);

            // RoleId Foreign Key olarak tanımlanır
            builder.Property(u => u.RoleId).IsRequired();


            builder.Property(p => p.Ad).HasMaxLength(50);
            builder.Property(p => p.Soyad).HasMaxLength(50);
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(256);

            builder.Property(p => p.TcNo) .HasMaxLength(11);
            builder.HasIndex(p => p.TcNo).IsUnique();

            builder.Property(u => u.IsActive).IsRequired();

            builder.Property(c => c.PhoneNumber)
                   .IsRequired(false)
                   .HasMaxLength(15);

            // Navigation Properties
            builder.HasOne(u => u.Role)
                   .WithOne(r => r.User)
                   .HasForeignKey<User>(u => u.RoleId);

            builder.HasMany(u => u.Orders)
                   .WithOne(o => o.User)
                   .HasForeignKey(o => o.UserId);

            // Navigation Property - One-to-Many Relationship (Customer -> Addresses)
            builder.HasMany(c => c.Addresses)
                   .WithOne(a => a.User)
                   .HasForeignKey(a => a.UserId);
        }
    }
}
