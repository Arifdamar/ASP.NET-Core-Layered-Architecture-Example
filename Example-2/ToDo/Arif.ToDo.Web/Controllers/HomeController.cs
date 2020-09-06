using System.Threading.Tasks;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.DTO.DTOs.AppUserDTOs;
using Arif.ToDo.Entities.Concrete;
using Arif.ToDo.Web.BaseControllers;
using Arif.ToDo.Web.Consts;
using AutoMapper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Arif.ToDo.Web.Controllers
{
    public class HomeController : BaseIdentityController
    {
        private readonly ITaskService _taskService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly ICustomLogger _customLogger;

        public HomeController(ITaskService taskService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, ICustomLogger customLogger) : base(userManager)
        {
            _taskService = taskService;
            _signInManager = signInManager;
            _mapper = mapper;
            _customLogger = customLogger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserSignInDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.UserName);

                if (user != null)
                {
                    var identityResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

                    if (identityResult.Succeeded)
                    {
                        var userRoles = await UserManager.GetRolesAsync(user);

                        if (userRoles.Contains(AreaNames.Admin))
                        {
                            return RedirectToAction("Index", "Home", new { area = AreaNames.Admin });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = AreaNames.Member });
                        }
                    }
                }

                ModelState.AddModelError("", Messages.LoginError);
            }

            return View("Index", model);
        }

        public IActionResult Register()
        {
            return View(new AppUserAddDto());
        }

        [HttpPost]
        public async Task<IActionResult> Register(AppUserAddDto model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<AppUser>(model);
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var addRoleResult = await UserManager.AddToRoleAsync(user, Roles.Member);

                    if (addRoleResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }

                    AddErrorRange(addRoleResult.Errors);
                }

                AddErrorRange(result.Errors);
            }

            return View(model);
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index");
        }

        public IActionResult StatusCode(int? code)
        {
            if (code == 404)
            {
                ViewBag.Code = code;
                ViewBag.Message = Messages.PageNotFound;
            }

            return View();
        }

        public IActionResult Error()
        {
            var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            _customLogger.LogError($"Hatanın oluştuğu yer: {exceptionHandler.Path}\nHatanın mesajı :{exceptionHandler.Error.Message}\nStack Trace: {exceptionHandler.Error.StackTrace}");
            ViewBag.Path = exceptionHandler.Path;
            ViewBag.Message = exceptionHandler.Error.Message;

            return View();
        }
    }
}
