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
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                //Elbise, Etek, Kaban, Mont, T-Shirt, Kazak, Pantolon, Tulum, Gömlek"
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Elbise",
                    Description = "Kadın ve Kız Çocuk Giyim"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Etek",
                    Description = "Kadın ve Kız Çocuk Giyi"

                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Mont",
                    Description = "Kadın, Erkek ve Kız Çocuk, Erkek Çocuk giyim"

                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "T-Shirt",
                    Description = "Yazlık kaliteli Kadın, Erkek ve Kız Çocuk, Erkek Çocuk giyim"
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "Kazak",
                    Description = "Kışlık kaliteli Kadın, Erkek ve Kız Çocuk, Erkek Çocuk giyim"
                },
                new Category
                {
                    CategoryId = 6,
                    CategoryName = "Pantolon",
                    Description = "Mevsimlik kaliteli Kadın, Erkek ve Kız Çocuk, Erkek Çocuk giyim"
                },
                new Category
                {
                    CategoryId = 7,
                    CategoryName = "Gömlek",
                    Description = "Mevsimlik kaliteli Kadın, Erkek ve Kız Çocuk, Erkek Çocuk giyim"
                },
                new Category
                {
                    CategoryId = 8,
                    CategoryName = "Gözlük",
                    Description = "Aksesuar"

                },
                new Category
                {
                    CategoryId = 9,
                    CategoryName = "Flor",
                    Description = "Aksesuar"

                },
                new Category
                {
                    CategoryId = 10,
                    CategoryName = "Abiye Çanta",
                    Description = "Çanta"

                },
                new Category
                {
                    CategoryId = 11,
                    CategoryName = " Günlük Çanta",
                    Description = "Çanta"
                },
                new Category
                {
                    CategoryId = 12,
                    CategoryName = "Sırt Çantası",
                    Description = "Çanta"
                }
            );
        }
    }
}
