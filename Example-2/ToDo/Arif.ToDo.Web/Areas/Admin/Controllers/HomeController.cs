using System.Threading.Tasks;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.Entities.Concrete;
using Arif.ToDo.Web.BaseControllers;
using Arif.ToDo.Web.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Arif.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    [Area(AreaNames.Admin)]
    public class HomeController : BaseIdentityController
    {
        private readonly ITaskService _taskService;
        private readonly INotificationService _notificationService;
        private readonly IReportService _reportService;

        public HomeController(ITaskService taskService, INotificationService notificationService, UserManager<AppUser> userManager, IReportService reportService) : base(userManager)
        {
            _taskService = taskService;
            _notificationService = notificationService;
            _reportService = reportService;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = ActivePage.Homepage;
            var user = await GetCurrentUser();
            ViewBag.UnassignedTaskCount = _taskService.GetUnassignedTaskCount();
            ViewBag.CompletedTaskCount = _taskService.GetCompletedTaskCount();
            ViewBag.UnreadNotificationCount = _notificationService.GetUnreadNotificationCountByUserId(user.Id);
            ViewBag.TotalReportCount = _reportService.GetTotalReportCount();

            return View();
        }
    }
}
