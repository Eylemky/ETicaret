using ETicaretBL.Managers.Abstract;
using ETicaretEntity.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretMVC.Controllers
{
    public class AccountController(IManager<Role> roleManager, IManager<User> userManager) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
