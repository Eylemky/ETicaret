﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretEntity.Entities.Concrete
{
    public class Address
    {
        public int AddressId { get; set; }
        public int UserId { get; set; } // Foreign Key
        public string AddressLine { get; set; }
        public  string AddressDescription { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        // Navigation Property
        public User User { get; set; }
    }
}
