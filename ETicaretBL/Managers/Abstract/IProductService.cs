using ETicaretEntity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.BL.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task AddProductAsync(Product product);
    }
}
