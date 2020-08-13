using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Arif.ToDo.Entities.Concrete;
using Arif.ToDo.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        public async Task<IActionResult> Index(AppUserListViewModel model, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                var userToUpdate = await _userManager.Users.FirstOrDefaultAsync(I => I.Id == model.Id);

                if (userToUpdate.Name == model.Name && userToUpdate.SurName == model.SurName && userToUpdate.Email == model.Email && userToUpdate.Picture == model.Picture)
                {
                    return View(model);
                }

                if (photo != null)
                {
                    string extension = Path.GetExtension(photo.FileName);
                    string photoName = Guid.NewGuid() + extension;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + photoName);
                    await using var stream = new FileStream(path, FileMode.Create);
                    await photo.CopyToAsync(stream);
                    userToUpdate.Picture = photoName;
                }

                userToUpdate.Name = model.Name;
                userToUpdate.SurName = model.SurName;
                userToUpdate.Email = model.Email;

                var result = await _userManager.UpdateAsync(userToUpdate);

                if (result.Succeeded)
                {
                    TempData["message"] = "Güncelleme işlemi başarıyla tamamlandı";

                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }

            return View(model);
        }
    }
}
