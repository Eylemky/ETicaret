using ETicaret.DAL.Repositories.Abstract;
using ETicaret.Entities.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretBL.Managers.Abstract
{
    public interface IManager<T> : IRepository<T> where T : BaseEntity
    {
        
    }
}
