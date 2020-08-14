using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.Entities.Concrete;
using Arif.ToDo.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Task = Arif.ToDo.Entities.Concrete.Task;

namespace Arif.ToDo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(ITaskService taskService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _taskService = taskService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserSignInModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null)
                {
                    var identityResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

                    if (identityResult.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);

                        if (userRoles.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "Member" });
                        }
                    }
                }

                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
            }

            return View("Index", model);
        }

        public IActionResult Register()
        {
            return View(new AppUserAddViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(AppUserAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Name = model.Name,
                    SurName = model.SurName
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var addRoleResult = await _userManager.AddToRoleAsync(user, "Member");

                    if (addRoleResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }

                    foreach (var error in addRoleResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }

            return View(model);
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index");
        }
    }
}
