using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arif.ToDo.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arif.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TaskOrderController : Controller
    {
        private readonly IAppUserService _appUserService;

        public TaskOrderController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            var model = _appUserService.GetNonAdminUsers();

            return View();
        }
    }
}
