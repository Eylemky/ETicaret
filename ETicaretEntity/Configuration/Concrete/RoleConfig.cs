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
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            // Id anahtar olarak tanımlanır
            builder.HasKey(r => r.RoleId);

            // Diğer alanlar
            builder.Property(r => r.RoleName).IsRequired().HasMaxLength(100);

            // Navigation Property
            builder.HasOne(r => r.User)
                   .WithOne(u => u.Role)
                   .HasForeignKey<User>(u => u.RoleId);
        }
    }
}
