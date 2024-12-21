using ETicaret.Entities.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretEntity.Entities.Concrete
{
    public class Log : BaseEntity
    {
        public string LogType { get; set; } // Error, Info, Warning
        public string Message { get; set; }
        public string Details { get; set; }

    }
}
