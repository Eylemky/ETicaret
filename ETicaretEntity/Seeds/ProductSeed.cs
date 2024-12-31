using ETicaretEntity.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretEntity.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(

                new Product
                {
                    Id = 1,
                    CategoryId = 5,
                    Name = "Triko Kazak",
                    Description="%100 Pamuk kazak",
                    Price = 200,
                    Stock=243,
                    CreatedDate= DateTime.Now,
                    UpdatedDate= DateTime.Now,
                },
                new Product
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = " Elbise",
                    Description = "Müslim kumaş mevsimlik",
                    Price = 460,
                    Stock = 243,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new Product
                {
                    Id = 3,
                    CategoryId = 4,
                    Name = " T-Shirt",
                    Description = "Mevsimlik",
                    Price = 347,
                    Stock = 243,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                }

            );
        }
    }
}
