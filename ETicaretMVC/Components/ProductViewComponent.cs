using ETicaretBL.Managers.Abstract;
using ETicaretEntity.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretMVC.Components
{
    public class ProductListViewComponent 
    {
        private readonly IManager<Product> productManager;

        public ProductListViewComponent(IManager<Product> productManager)
        {
            this.productManager = productManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var product = productManager.GetAllAsync();
            return View(product);
        }

        private IViewComponentResult View(Task<IEnumerable<Product>> product)
        {
            throw new NotImplementedException();
        }
    }
}
