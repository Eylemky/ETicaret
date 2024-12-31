using ETicaretEntity.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretEntity.Seeds
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasData(

           new Order
           {
               Id = 1,
               UserId = 3,
               AddressId = 1,
               OrderDate = new DateOnly(2024, 10, 18), //18 Ekim 2024
               RequiredDate = new DateOnly(2024, 10, 22), //Tahmini Teslimat Tarihi
               ShippedDate = new DateOnly(2024, 10, 20), //kargoya verilen tarih
               ShipperId = 1
           }
        );
    }
}
