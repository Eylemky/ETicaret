using ETicaret.Entities.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace ETicaret.Entities.Configuration.Abstract
{
    public abstract class BaseConfig<T> : IEntityTypeConfiguration<BaseEntity> 
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            // Id anahtar olarak tanımlanır
            builder.HasKey(e => e.Id);

            // CreatedDate varsayılan olarak şu anki tarih olarak ayarlanır
            builder.Property(e => e.CreatedDate).ValueGeneratedOnAdd().
                HasDefaultValueSql("GETDATE()");

            // UpdatedDate, varsayılan olarak null ve güncellenebilir olacak şekilde ayarlanır
            builder.Property(e => e.UpdatedDate)
                .IsRequired(false);
        }
    }

}