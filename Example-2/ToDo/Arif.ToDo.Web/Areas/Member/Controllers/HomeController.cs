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
        private readonly ITaskService _taskService;
        private readonly INotificationService _notificationService;

        public HomeController(IReportService reportService, UserManager<AppUser> userManager, ITaskService taskService, INotificationService notificationService)
        {
            _reportService = reportService;
            _userManager = userManager;
            _taskService = taskService;
            _notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "homePage";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.ReportCount = _reportService.GetReportCountByUserId(user.Id);
            ViewBag.CompletedTaskCount = _taskService.GetCompletedTaskCountByUserId(user.Id);
            ViewBag.UnreadNotificationCount = _notificationService.GetUnreadNotificationCountByUserId(user.Id);
            ViewBag.UndoneTaskCount = _taskService.GetUndoneTaskCountByUserId(user.Id);

            return View();
        }
    }
}
