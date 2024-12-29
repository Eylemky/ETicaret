using ETicaret.Entities.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretEntity.Entities.Concrete
{
    public class OrderDetail 
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; } // Foreign Key
        public int ProductId { get; set; } // Foreign Key
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        // Navigation Properties
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
