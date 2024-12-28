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

        [HttpGet]
        public async Task<IActionResult> User()
        {
            // Asenkron işlemi await ile alıp
            var users = await userManager.GetAllIncludeAsync(null, p => p.Role);

            // Sonucu listeye dönüştür
            var userList = users.ToList();
            return View(userList);
        }
    }
}
