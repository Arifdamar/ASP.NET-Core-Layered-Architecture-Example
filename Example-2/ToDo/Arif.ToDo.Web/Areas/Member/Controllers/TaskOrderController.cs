using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.Entities.Concrete;
using Arif.ToDo.Web.Areas.Admin.Models;
using Arif.ToDo.Web.Areas.Member.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Arif.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class TaskOrderController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IReportService _reportService;
        private readonly UserManager<AppUser> _userManager;
        private readonly INotificationService _notificationService;

        public TaskOrderController(ITaskService taskService, IReportService reportService, UserManager<AppUser> userManager, INotificationService notificationService)
        {
            _taskService = taskService;
            _reportService = reportService;
            _userManager = userManager;
            _notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "taskOrder";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var tasks = _taskService.GetAllTasksWithAllFields(I => I.AppUserId == user.Id && !I.Status);

            List<AllTasksListViewModel> model = new List<AllTasksListViewModel>();

            tasks.ForEach(task =>
            {
                model.Add(new AllTasksListViewModel()
                {
                    Id = task.Id,
                    AppUser = task.AppUser,
                    CratedDate = task.CreatedDate,
                    Description = task.Description,
                    Name = task.Name,
                    Report = task.Report,
                    Urgency = task.Urgency
                });
            });

            return View(model);
        }

        #region AddReport
        public IActionResult AddReport(int id)
        {
            TempData["Active"] = "taskOrder";
            var task = _taskService.GetTaskByIdWithUrgency(id);

            ReportAddViewModel model = new ReportAddViewModel()
            {
                Task = task,
                TaskId = id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReport(ReportAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _reportService.Save(new Report()
                {
                    TaskId = model.TaskId,
                    Definition = model.Definition,
                    Description = model.Description
                });
                var adminUserList = await _userManager.GetUsersInRoleAsync("Admin").ConfigureAwait(true);
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                foreach (var admin in adminUserList)
                {
                    _notificationService.Save(new Notification()
                    {
                        Description = $"{user.Name} {user.SurName} yeni bir rapor yazdı.",
                        AppUserId = admin.Id
                    });
                }

                return RedirectToAction("Index");
            }

            return View(model);
        }
        #endregion

        #region UpdateReport
        public IActionResult UpdateReport(int id)
        {
            TempData["Active"] = "taskOrder";
            var report = _reportService.GetReportByIdWithTask(id);
            var task = _taskService.GetTaskByIdWithUrgency(report.TaskId);

            ReportUpdateViewModel model = new ReportUpdateViewModel()
            {
                Id = id,
                Definition = report.Definition,
                Description = report.Description,
                Task = task
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateReport(ReportUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var reportToUpdate = _reportService.GetById(model.Id);
                reportToUpdate.Definition = model.Definition;
                reportToUpdate.Description = model.Description;
                _reportService.Update(reportToUpdate);

                return RedirectToAction("Index");
            }

            return View(model);
        }
        #endregion

        public async Task<IActionResult> CompleteTask(int id)
        {
            var taskToUpdate = _taskService.GetById(id);
            taskToUpdate.Status = true;
            _taskService.Update(taskToUpdate);
            var adminUserList = await _userManager.GetUsersInRoleAsync("Admin").ConfigureAwait(true);
            var user = await _userManager.FindByNameAsync(User.Identity.Name).ConfigureAwait(true);

            foreach (var admin in adminUserList)
            {
                _notificationService.Save(new Notification()
                {
                    Description = $"{user.Name} {user.SurName}, {taskToUpdate.Name} görevini tamamladı.",
                    AppUserId = admin.Id
                });
            }

            return Json(null);
        }

    }
}
