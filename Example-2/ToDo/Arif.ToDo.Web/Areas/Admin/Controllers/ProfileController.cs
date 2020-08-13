using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arif.ToDo.Entities.Concrete;
using Arif.ToDo.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Arif.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "profile";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
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
