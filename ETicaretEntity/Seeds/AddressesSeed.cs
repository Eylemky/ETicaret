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
    public class AddressSeed : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
        //     public int AddressId { get; set; }
        //public int UserId { get; set; } // Foreign Key
        //public string AddressLine { get; set; }
        //public string City { get; set; }
        //public string State { get; set; }
        //public string PostalCode { get; set; }
        //public string Country { get; set; }

        builder.HasData(

                new Address
                {
                    AddressId = 1,
                    UserId = 1,
                    AddressLine = "Home",
                    AddressDescription = "Barış Caddesi, Sümbül Sokağı, Kuş Apartmanı No:34 / Daire:4",
                    State = "Kadıköy",
                    City = "İstanbul"
                },
                new Address
                {
                    AddressId = 2,
                    UserId = 5,
                    AddressLine = "Annemler",
                    AddressDescription = "Çağla Mahallesi, Martı Apartmanı No:21 Daire:8",
                    State = "Mustafakemalpaşa",
                    City = "Samsun"
                },
                new Address
                {
                    AddressId = 3,
                    UserId = 3,
                    AddressLine = "Evim",
                    AddressDescription = "Yaşar Sokak, Sarnış Apt. No:6 Daire:1",
                    State = "Karşıyaka",
                    City = "İzmir"
                },
                new Address
                {
                    AddressId = 4,
                    UserId = 2,
                    AddressLine = "Office",
                    AddressDescription = "Atatürk Mahallesi, Savaş Sokak, Cumhuriyet Apt. No:18 Daire:3",
                    State = "Maltepe",
                    City = "İstanbul"
                },
                new Address
                {
                    AddressId = 5,
                    UserId = 4,
                    AddressLine = "IlkEvim",
                    AddressDescription = "Sarıca  Mh. , Pervane Sokak, Özdemir Sitesi G Blok Daire:13",
                    State = "Çankaya",
                    City = "Ankara"
                }
            );
        }
    }
}
