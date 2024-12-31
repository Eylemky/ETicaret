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
    public class PaymentSeed : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasData(
            new Payment
            {
                PaymentId = 1,
                OrderId = 1, 
                Amount = 150.50m,
                PaymentDate = new DateTime(2023, 12, 1),
                PaymentMethod = "CreditCard",
                IsSuccessful = true
            },
            new Payment
            {
                PaymentId = 2,
                OrderId = 2, 
                Amount = 200.00m,
                PaymentDate = new DateTime(2023, 12, 2),
                PaymentMethod = "PayPal",
                IsSuccessful = true
            },
            new Payment
            {
                PaymentId = 3,
                OrderId = 3, 
                Amount = 99.99m,
                PaymentDate = new DateTime(2023, 12, 3),
                PaymentMethod = "BankTransfer",
                IsSuccessful = false
            });
        }   
    }
}
