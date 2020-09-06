using System.Threading.Tasks;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.Entities.Concrete;
using Arif.ToDo.Web.BaseControllers;
using Arif.ToDo.Web.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Arif.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles = Roles.Member)]
    [Area(AreaNames.Member)]
    public class HomeController : BaseIdentityController
    {
        private readonly IReportService _reportService;
        private readonly ITaskService _taskService;
        private readonly INotificationService _notificationService;

        public HomeController(IReportService reportService, UserManager<AppUser> userManager, ITaskService taskService, INotificationService notificationService) : base(userManager)
        {
            _reportService = reportService;
            _taskService = taskService;
            _notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = ActivePage.Homepage;
            var user = await GetCurrentUser();
            ViewBag.ReportCount = _reportService.GetReportCountByUserId(user.Id);
            ViewBag.CompletedTaskCount = _taskService.GetCompletedTaskCountByUserId(user.Id);
            ViewBag.UnreadNotificationCount = _notificationService.GetUnreadNotificationCountByUserId(user.Id);
            ViewBag.UndoneTaskCount = _taskService.GetUndoneTaskCountByUserId(user.Id);

            return View();
        }
    }
}
