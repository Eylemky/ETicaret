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

            new User
            {
                Id = 1,
                Name = "Felix",
                Surname = "Runtenten",
                Email = "felixruntenten@gmail.com",
                PhoneNumber = "+90 555 333 55 33",
                RoleId = 1, //Customer
                PasswordHash = "qweasd",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
             },
            new User
            {
                Id = 2,
                Name = "Fahri",
                Surname = "Feneroğlu",
                Email = "fahri_feneroğlu@gmail.com",
                PhoneNumber = "+90 535 555 35 44",
                RoleId = 1, //Customer
                PasswordHash = "qweasd1", //PasswordHash doğrudan db'ye kaydedilmemeli Hash İşlemleri olmalı
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now

            },
            new User
            {
                Id = 3,
                Name = "İrem",
                Surname = "Çelik",
                Email = "iremozyurt@gmail.com",
                PhoneNumber = "+90 555 444 22 34",
                RoleId = 1,
                PasswordHash = "qweasd2",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },

            new User
            {
                Id = 4,
                Name = "Adem",
                Surname = "Donmez",
                Email = "ademdonmez@gmail.com",
                PhoneNumber = "+90 532 625 54 34",
                RoleId = 1,
                PasswordHash = "qweasd3",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },

            new User
            {
                Id = 5,
                Name = "Jush",
                Surname = "Hutcerson",
                Email = "jush_hutcersen@gmail.com",
                PhoneNumber = "+90 555 435 33 55",
                RoleId = 1,
                PasswordHash = "qweasd4",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },

            new User
            {
                Id = 6,
                Name = "Eylem",
                Surname = "Kaya Donmez",
                Email = "eylemdonmez@admin.com",
                PhoneNumber = "+90 555 465 88 22",
                RoleId = 2,
                PasswordHash = "qweasdadmin",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new User
            {
                Id = 7,
                Name = "Ercan",
                Surname = "Öztürk",
                Email = "ercanozturk@admin.com",
                PhoneNumber = "+90 555 425 55 24",
                RoleId = 2,
                PasswordHash ="qweasdpro",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            }
            );
        }
    }
}
