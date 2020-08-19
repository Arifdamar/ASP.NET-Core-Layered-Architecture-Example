using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Arif.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly INotificationService _notificationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IReportService _reportService;

        public HomeController(ITaskService taskService, INotificationService notificationService, UserManager<AppUser> userManager, IReportService reportService)
        {
            _taskService = taskService;
            _notificationService = notificationService;
            _userManager = userManager;
            _reportService = reportService;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "homePage";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UnassignedTaskCount = _taskService.GetUnassignedTaskCount();
            ViewBag.CompletedTaskCount = _taskService.GetCompletedTaskCount();
            ViewBag.UnreadNotificationCount = _notificationService.GetUnreadNotificationCountByUserId(user.Id);
            ViewBag.TotalReportCount = _reportService.GetTotalReportCount();

            return View();
        }
    }
}
