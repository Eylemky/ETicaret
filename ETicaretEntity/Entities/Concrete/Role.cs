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

        // Bir rol birden fazla kullanıcıya sahip olabilir
        public ICollection<User> User { get; set; }
    }
}
