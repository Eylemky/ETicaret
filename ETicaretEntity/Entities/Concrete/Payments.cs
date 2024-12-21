using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretEntity.Entities.Concrete
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; } // Foreign Key
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } // CreditCard, PayPal, etc.
        public bool IsSuccessful { get; set; }

        // Navigation Property
        public Order Order { get; set; }
    }
}
