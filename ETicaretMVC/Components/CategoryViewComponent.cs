using ETicaretBL.Managers.Abstract;
using ETicaretEntity.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ETicaretMVC.Components
{
    public class CategoryViewComponent
    {
        //************* hatalı kodlar *************
        //private readonly IManager<Category> category_Manager;

        //public CategoryViewComponent(IManager<Category> categoryManager)
        //{
        //    this.category_Manager = categoryManager;
        //}

        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var categories = await category_Manager.GetAllAsync();
        //    return View(categories);
        //}

        //private IViewComponentResult View(IEnumerable<Category> categories)
        //{
        //    throw new NotImplementedException();
        //}
    }
}