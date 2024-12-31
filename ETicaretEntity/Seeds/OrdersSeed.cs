using ETicaret.Entities.Entities.Abstract;
using ETicaretEntity.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretEntity.Seeds
{
    public class OrderSeed : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(
               new Order
               {
                   Id = 1,
                   UserId = 3,
                   OrderStatusId = 1,
                   TotalAmount = 250,
                   Status = "Pending",
                   ShippingAddress = "Barış Caddesi, Sümbül Sokağı, Kuş Apartmanı No:34 / Daire:4",
                   PaymentMethod = "Card",
                   CreatedDate = new DateOnly(2024, 06, 05),
                   RequiredDate = new DateOnly(2024, 06, 10), //Tahmini Teslimat Tarihi
                   ShippedDate = new DateOnly(2024, 06, 08), //kargoya verilen tarih
               },
               new Order
               {
                   Id = 2,
                   UserId = 3,
                   OrderStatusId = 2,
                   TotalAmount = 250,
                   Status = "Completed",
                   ShippingAddress = "Çağla Mahallesi, Martı Apartmanı No:21 Daire:8",
                   PaymentMethod = "CreditCard",
                   CreatedDate = new DateOnly(2024, 10, 18), //18 Ekim 2024
                   RequiredDate = new DateOnly(2024, 10, 22), //Tahmini Teslimat Tarihi
                   ShippedDate = new DateOnly(2024, 10, 20), //kargoya verilen tarih

               },
               new Order
               {
                   Id = 3,
                   UserId = 1,
                   OrderStatusId = 3,
                   TotalAmount = 250,
                   Status = "Canceled",
                   ShippingAddress = "Yaşar Sokak, Sarnış Apt. No:6 Daire:1",
                   PaymentMethod = "CreditCard",
                   CreatedDate = new DateOnly(2024, 04, 30), //18 Ekim 2024
                   RequiredDate = new DateOnly(2024, 05, 04), //Tahmini Teslimat Tarihi
                   ShippedDate = new DateOnly(2024, 05, 03), //kargoya verilen tarih
               }
            );
        }
    }
}
