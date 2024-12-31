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
    public class OrderStatusSeed : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasData(
                 new OrderStatus { OrderStatusId = 1, StatusName = "Pending" },
                 new OrderStatus { OrderStatusId = 2, StatusName = "Completed" },
                 new OrderStatus { OrderStatusId = 3, StatusName = "Canceled" }



                );
        }
    } 
}
