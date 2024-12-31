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
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            // Id anahtar olarak tanımlanır
            builder.HasKey(r => r.Id);

            // Name özelliği zorunlu ve maksimum uzunluğu 50 karakter
            builder.Property(r => r.RoleName)
                   .IsRequired()
                   .HasMaxLength(50);

            // Role ile User ilişkisi (Bire-çok ilişki)
            builder.HasMany(r => r.User) // Role sınıfında Users koleksiyonu tanımlı olmalı
                   .WithOne(u => u.Role) // User sınıfında Role tanımlı olmalı
                   .HasForeignKey(u => u.RoleId)
                   .OnDelete(DeleteBehavior.Restrict); // Silme davranışı düzenlendi
        }
    }
}
