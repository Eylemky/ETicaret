using ETicaret.DAL.Repositories.Abstract;
using ETicaretEntity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.BL.Services
{
    public class ProductManager : IProductManager
    {
        private readonly IRepository<Product> _repository;

        public ProductManager(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> GetAllProductsAsync() => (await _repository.GetAllAsync()).ToList();
        public async Task AddProductAsync(Product product) => await _repository.AddAsync(product);
    }
}
