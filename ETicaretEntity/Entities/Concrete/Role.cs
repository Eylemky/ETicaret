using ETicaret.Entities.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretEntity.Entities.Concrete
{
    public class Role:BaseEntity
    {
        public string RoleName { get; set; }

        // Navigation Property
        public User User { get; set; }
    }
}
