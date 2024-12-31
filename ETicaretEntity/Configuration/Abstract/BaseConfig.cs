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

        }
    }

}