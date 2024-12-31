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
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(

            //            new User
            //            {
            //                Id = 1,
            //                Name = "Tom",
            //                SurName = "Hardy",
           
            //                Email = "tomhardy@gmail.com",
            //                BirthDate = new DateOnly(1977, 9, 15),
            //                Phone = "+90 555 555 55 55",
            //                RoleId = 1, //Customer
            //                Password = "qweasd"
            //            },
            //            new User
            //            {
            //                Id = 2,
            //                FirstName = "Furkan",
            //                LastName = "Yeneroğlu",
            //                Email = "furkan_yeneroğlu@gmail.com",
            //                BirthDate = new DateOnly(2002, 12, 17),
            //                Phone = "+90 555 555 55 44",
            //                RoleId = 1, //Customer
            //                Password = "qweasd"
            //                //Password doğrudan db'ye kaydedilmemeli Hash İşlemleri olmalı
            //            },
            //            new User
            //            {
            //                Id = 3,
            //                FirstName = "İrem Nur",
            //                LastName = "Özyurt",
            //                Email = "iremozyurt@gmail.com",
            //                BirthDate = new DateOnly(2002, 10, 21),
            //                Phone = "+90 555 555 55 34",
            //                RoleId = 1,
            //                Password = "qweasd"
            //            },
            //            new User
            //            {
            //                Id = 4,
            //                FirstName = "İldem",
            //                LastName = "Çakıcı",
            //                Email = "ildemcakici@gmail.com",
            //                BirthDate = new DateOnly(2005, 10, 04),
            //                Phone = "+90 555 555 54 34",
            //                RoleId = 1,
            //                Password = "qweasd"
            //            },
            //            new User
            //            {
            //                Id = 5,
            //                FirstName = "Henry",
            //                LastName = "Cavill",
            //                Email = "henrycavill@gmail.com",
            //                BirthDate = new DateOnly(1983, 05, 05),
            //                Phone = "+90 555 555 33 55",
            //                RoleId = 1,
            //                Password = "qweasd"
            //            },
            //            new User
            //            {
            //                Id = 6,
            //                FirstName = "Şevval",
            //                LastName = "Özdemir",
            //                Email = "sevval@admin.com",
            //                BirthDate = new DateOnly(2002, 11, 24),
            //                Phone = "+90 555 555 51 34",
            //                RoleId = 2,
            //                Password = "qweasd"
            //            },
            //            new User
            //            {
            //                Id = 7,
            //                FirstName = "Ercan",
            //                LastName = "Öztürk",
            //                Email = "ercan@admin.com",
            //                Phone = "+90 555 555 55 24",
            //                RoleId = 2,
            //                Password = "qweasd"
            //            }
            );
        }
    }
}
