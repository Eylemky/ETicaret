using ETicaretBL.Managers.Abstract;
using ETicaretEntity.Entities.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using ETicaretMVC.Models.ViewModels;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace ETicaretMVC.Controllers
{
    [Authorize]
    public class AccountController(IManager<User> userManager, IManager<Role> roleManager, IManager<User> adminManager, WebDbContext dbContext, INotyfService notyfService) : Controller
    {
        public IActionResult Account()
        {
            // Kullanıcıyı SignIn aksiyonuna yönlendir
            return RedirectToAction("SignIn", "Auth");
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            LoginVM loginVM = new LoginVM();
            return View(loginVM);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var user = userManager.GetAllIncludeAsync(p => p.Email == loginVM.Email && p.PasswordHash == loginVM.Password).Result.FirstOrDefault();
            var admin = adminManager.GetAllIncludeAsync(p => p.Email == loginVM.Email && p.PasswordHash == loginVM.Password).Result.FirstOrDefault();

            if (user == null)
            {
                if (admin == null)
                {
                    notyfService.Error("Mail ya da Şifre Hatalı");
                    return View(loginVM);
                }
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,loginVM.Email)
            };

            if (user != null)
            {
                claims.Add(new Claim("UserId", user.Id.ToString()));
            }


            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authenticationProperty = new AuthenticationProperties()
            {
                IsPersistent = loginVM.RememberMe
            };

            var userPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, authenticationProperty);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #region Yeni Kullanıcı Kayıt İşlemleri

        [HttpGet]
        [AllowAnonymous]
        public IActionResult UserInsert()
        {
            UserInsertVM userInsertVM = new UserInsertVM();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult UserInsert(UserInsertVM userInsertVM)
        {
            if (!ModelState.IsValid)
            {
                notyfService.Error("You need to check your informations");
                return View(userInsertVM);
            }

            User user = new User();
            user.Name = userInsertVM.FirstName;
            user.Surname = userInsertVM.LastName;
            user.Email = userInsertVM.Email;
            user.PhoneNumber = userInsertVM.Phone;
            user.PasswordHash = userInsertVM.Password;

            notyfService.Success("İşlem başarılı.");

            userManager.AddAsync(user);

            notyfService.Success("mission is possible");

            return RedirectToAction("Login", "Account");

        }
        #endregion
    }
} 