using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretEntity.Entities.Concrete;
using ETicaret.Entities.Configuration.Abstract;
using System.Reflection.Emit;

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

            // Role ile ilişki (Bire-çok ilişki)
            builder.HasOne(u => u.Role)
                   .WithMany(r => r.User) // Rol birden fazla kullanıcıya sahip olabilir
                   .HasForeignKey(u => u.RoleId)
                   .OnDelete(DeleteBehavior.Restrict); // Silme davranışı düzenlendi

            // Diğer Property Ayarları
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.Surname)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.PasswordHash)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.Property(u => u.IsActive)
                   .IsRequired();

            builder.Property(c => c.PhoneNumber)
                   .IsRequired(false)
                   .HasMaxLength(20);

            // CreatedDate varsayılan olarak şu anki tarih olarak ayarlanır
            builder.Property(e => e.CreatedDate)
                   .ValueGeneratedOnAdd()
                   .HasDefaultValueSql("GETDATE()");

            // UpdatedDate, varsayılan olarak null ve güncellenebilir olacak şekilde ayarlanır
            builder.Property(e => e.UpdatedDate)
                   .IsRequired(false);

            // User ile Orders ilişkisi (Bire-çok ilişki)
            builder.HasMany(u => u.Orders)
                   .WithOne(o => o.User)
                   .HasForeignKey(o => o.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            // User ile Addresses ilişkisi (Bire-çok ilişki)
            builder.HasMany(c => c.Addresses)
                   .WithOne(a => a.User)
                   .HasForeignKey(a => a.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
