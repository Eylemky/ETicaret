using AspNetCoreHero.ToastNotification;
using ETicaretMVC.Extensions;
using ETicaretMVC.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace ETicaretMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<EmailService>();


            #region DbContext Registiration
            var constr = builder.Configuration.GetConnectionString("Ticari");
            builder.Services.AddDbContext<WebDbContext>(options => options.UseSqlServer(constr));
            #endregion

            #region Notify Configuration
            builder.Services.AddNotyf(p =>
            {
                p.Position = NotyfPosition.BottomRight;
                p.DurationInSeconds = 5;
                p.IsDismissable = true;
            });
            #endregion

            #region Cookie Base Authentication
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.Name = "MySiteCookie";
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.Cookie.HttpOnly = true; //Tarayýcýdaki di?er scriptler okuyamasýn diye güvenlik 
                options.Cookie.SameSite = SameSiteMode.Strict; //Baska tarayicilar tarafindan ulasilamasin diye güvenlik önlemi
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.SlidingExpiration = true; //Herhangi sitede bir hareket oldugunda süreyi 10 dk uzatir.
            });
            #endregion

            builder.Services.AddTicariService();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
