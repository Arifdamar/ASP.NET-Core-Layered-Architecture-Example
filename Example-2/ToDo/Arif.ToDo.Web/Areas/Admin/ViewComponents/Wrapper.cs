using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arif.ToDo.Entities.Concrete;
using Arif.ToDo.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Arif.ToDo.Web.Areas.Admin.ViewComponents
{
    public class Wrapper : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public Wrapper(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            // ReSharper disable once AsyncConverter.AsyncWait
            var user = _userManager.FindByNameAsync(User.Identity?.Name).Result;
            AppUserListViewModel model = new AppUserListViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                SurName = user.SurName,
                Email = user.Email,
                Picture = user.Picture
            };

            return View(model);
        }
    }
}
