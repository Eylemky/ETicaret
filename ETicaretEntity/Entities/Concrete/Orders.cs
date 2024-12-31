using ETicaret.Entities.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretEntity.Entities.Concrete
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; } // Foreign Key
        public int OrderStatusId { get; set; } // Foreign Key
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } // Pending, Completed, Canceled
        public string ShippingAddress { get; set; }
        public string PaymentMethod { get; set; } // CreditCard, PayPal, etc.
        public DateOnly CreatedDate { get; set; }
        public DateOnly? RequiredDate { get; set; }
        public DateOnly? ShippedDate { get; set; }


        // Navigation Property
        public User User { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Payment> Payments { get; set; } // New property
    }
}
