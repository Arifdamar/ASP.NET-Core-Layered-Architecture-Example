using System.Collections.Generic;
using System.Threading.Tasks;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.DTO.DTOs.ReportDTOs;
using Arif.ToDo.DTO.DTOs.TaskDTOs;
using Arif.ToDo.Entities.Concrete;
using Arif.ToDo.Web.BaseControllers;
using Arif.ToDo.Web.Consts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Arif.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles = Roles.Member)]
    [Area(AreaNames.Member)]
    public class TaskOrderController : BaseIdentityController
    {
        private readonly ITaskService _taskService;
        private readonly IReportService _reportService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public TaskOrderController(ITaskService taskService, IReportService reportService, UserManager<AppUser> userManager, INotificationService notificationService, IMapper mapper) : base(userManager)
        {
            _taskService = taskService;
            _reportService = reportService;
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = ActivePage.TaskOrder;
            var user = await GetCurrentUser();

            return View(_mapper.Map<List<TaskListAllDto>>(_taskService.GetAllTasksWithAllFields(I => I.AppUserId == user.Id && !I.Status)));
        }

        #region AddReport
        public IActionResult AddReport(int id)
        {
            TempData["Active"] = ActivePage.TaskOrder;
            var task = _taskService.GetTaskByIdWithUrgency(id);

            ReportAddDto model = new ReportAddDto()
            {
                Task = task,
                TaskId = id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReport(ReportAddDto model)
        {
            if (ModelState.IsValid)
            {
                _reportService.Save(new Report()
                {
                    TaskId = model.TaskId,
                    Definition = model.Definition,
                    Description = model.Description
                });
                var adminUserList = await UserManager.GetUsersInRoleAsync(Roles.Admin);
                var user = await GetCurrentUser();

                foreach (var admin in adminUserList)
                {
                    _notificationService.Save(new Notification()
                    {
                        Description = $"{user.Name} {user.SurName}, {_taskService.GetById(model.TaskId).Name} görevine yeni bir rapor yazdı.",
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
            TempData["Active"] = ActivePage.TaskOrder;
            var report = _reportService.GetReportByIdWithTask(id);

            ReportUpdateDto model = new ReportUpdateDto()
            {
                Id = id,
                Definition = report.Definition,
                Description = report.Description,
                Task = report.Task
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateReport(ReportUpdateDto model)
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
            var adminUserList = await UserManager.GetUsersInRoleAsync(Roles.Admin);
            var user = await GetCurrentUser();

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
