using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arif.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TaskOrderController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly ITaskService _taskService;

        public TaskOrderController(IAppUserService appUserService, ITaskService taskService)
        {
            _appUserService = appUserService;
            _taskService = taskService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = "taskOrder";
            //var model = _appUserService.GetNonAdminUsers();

            var tasks = _taskService.GetAllTasksWithAllFields();
            List<AllTasksListViewModel> model = new List<AllTasksListViewModel>();

            tasks.ForEach(task =>
            {
                model.Add(new AllTasksListViewModel()
                {
                    Id = task.Id,
                    AppUser = task.AppUser,
                    CratedDate = task.CratedDate,
                    Description = task.Description,
                    Name = task.Name,
                    Report = task.Report,
                    Urgency = task.Urgency
                });
            });

            return View(model);
        }

        public IActionResult Assign(int id, string keyword, int activePage = 1)
        {
            TempData["Active"] = "taskOrder";
            ViewBag.ActivePage = activePage;
            ViewBag.TotalPage = (int)Math.Ceiling((double)_appUserService.GetNonAdminUsers().Count / 3);
            var task = _taskService.GetTaskByIdWithUrgency(id);
            var personnel = _appUserService.GetNonAdminUsers(keyword, activePage);
            List<AppUserListViewModel> appUserListModels = new List<AppUserListViewModel>();

            personnel.ForEach(user =>
            {
                appUserListModels.Add(new AppUserListViewModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    SurName = user.SurName,
                    Picture = user.Picture
                });
            });

            ViewBag.Personnel = appUserListModels;

            TaskListViewModel taskModel = new TaskListViewModel()
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                CratedDate = task.CratedDate,
                Urgency = task.Urgency
            };

            return View(taskModel);
        }
    }
}
