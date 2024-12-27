using ETicaret.BL.Services;
using ETicaret.DAL.Repositories.Abstract;
using ETicaret.DAL.Repositories.Concrete;
using ETicaretBL.Managers.Abstract;
using ETicaretBL.Managers.Concrete;

namespace ETicaretMVC.Extensions
{
    public static class TicariExtensions
    {
        public static IServiceCollection AddTicariService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IManager<>), typeof(Manager<>));
            services.AddScoped(typeof(IProductManager), typeof(ProductManager));
            services.AddScoped(typeof(IUserManager), typeof(UserManager));

            return services;
        }
    }
}
