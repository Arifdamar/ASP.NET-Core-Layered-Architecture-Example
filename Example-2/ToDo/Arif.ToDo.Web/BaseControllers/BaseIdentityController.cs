using System.Collections.Generic;
using System.Threading.Tasks;
using Arif.ToDo.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Arif.ToDo.Web.BaseControllers
{
    public class BaseIdentityController : Controller
    {
        protected readonly UserManager<AppUser> UserManager;
        public BaseIdentityController(UserManager<AppUser> userManager)
        {
            UserManager = userManager;
        }

        protected async Task<AppUser> GetCurrentUser()
        {
            return await UserManager.FindByNameAsync(User.Identity.Name);
        }

        protected void AddErrorRange(IEnumerable<IdentityError> errors)
        {
            foreach (var error in errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}
