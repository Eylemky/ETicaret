using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretEntity.Entities.Concrete
{
    public class OrderStatus
    {
        public int OrderStatusId { get; set; }
        public string StatusName { get; set; } // Pending, Shipped, Delivered, Canceled

        // Navigation Property
        public ICollection<Order> Orders { get; set; }
    }
}
