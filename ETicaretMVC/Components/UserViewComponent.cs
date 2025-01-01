using ETicaretBL.Managers.Abstract;
using ETicaretEntity.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ETicaretMVC.Components
{
    public class UserViewComponent
    {
        private IManager<User> userManager;

        public UserViewComponent(IManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var users = userManager.GetAllAsync();
            return View(users);
            
        }

        private IViewComponentResult View(Task<IEnumerable<User>> users)
        {
            throw new NotImplementedException();
        }
    }
}
