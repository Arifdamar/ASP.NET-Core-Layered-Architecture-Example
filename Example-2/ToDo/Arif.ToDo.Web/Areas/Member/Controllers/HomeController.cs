using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Arif.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class HomeController : Controller
    {
        private readonly IReportService _reportService;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(IReportService reportService, UserManager<AppUser> userManager)
        {
            _reportService = reportService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "homePage";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.ReportCount = _reportService.GetReportCountByUserId(user.Id);


            return View();
        }
    }
}
