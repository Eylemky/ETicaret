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

        //[HttpPost]
        //public IActionResult Login(string email, string password)
        //{
        //    var user = userManager.GetUserByEmail(email);
        //    if (user != null && user.Password == password)
        //    {
        //        // Oturum açma işlemi
        //        return RedirectToAction("Index", "Home");
        //    }

        //    ViewBag.ErrorMessage = "Invalid credentials";
        //    return View();
        //}
    }
}
