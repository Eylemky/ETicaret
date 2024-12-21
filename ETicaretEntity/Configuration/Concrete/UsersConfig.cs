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
    public class UsersConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Id anahtar olarak tanımlanır
            builder.HasKey(u => u.Id);

            // RoleId Foreign Key olarak tanımlanır
            builder.Property(u => u.RoleId).IsRequired();

            // Diğer alanlar
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(256);
            builder.Property(u => u.IsActive).IsRequired();

            // Navigation Properties
            builder.HasOne(u => u.Role)
                   .WithOne(r => r.User)
                   .HasForeignKey<User>(u => u.RoleId);

            builder.HasMany(u => u.Orders)
                   .WithOne(o => o.User)
                   .HasForeignKey(o => o.UserId);
        }
    }
}
