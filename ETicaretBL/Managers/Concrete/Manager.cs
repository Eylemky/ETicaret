using ETicaret.DAL.Repositories.Concrete;
using ETicaret.Entities.Entities.Abstract;
using ETicaretBL.Managers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretBL.Managers.Concrete
{
    public class Manager<T> :Repository<T> , IManager<T> where T : BaseEntity
    {
        public Manager(WebDbContext context) : base(context)
        {
            
        }
    }
}
