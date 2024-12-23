using ETicaret.Entities.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretEntity.Entities.Concrete
{
    public class Banner
    {
        public int BannerId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string RedirectUrl { get; set; }
        public bool IsActive { get; set; } = true;

        // İlişki
        public int? CategoryId { get; set; } // Banner'ın isteğe bağlı bir kategoriye bağlı olması.
        public Category Category { get; set; }
    }
}
