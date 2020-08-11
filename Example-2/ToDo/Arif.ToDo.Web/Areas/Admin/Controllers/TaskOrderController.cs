using System;
using System.Collections.Generic;
using System.Linq;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.Entities.Concrete;
using Arif.ToDo.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Arif.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TaskOrderController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly ITaskService _taskService;
        private readonly UserManager<AppUser> _userManager;

        public TaskOrderController(IAppUserService appUserService, ITaskService taskService, UserManager<AppUser> userManager)
        {
            _appUserService = appUserService;
            _taskService = taskService;
            _userManager = userManager;
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
            var task = _taskService.GetTaskByIdWithUrgency(id);
            var personnel = _appUserService.GetNonAdminUsers(out var totalPage, keyword, activePage);
            ViewBag.ActivePage = activePage;
            ViewBag.TotalPages = totalPage;
            ViewBag.Keyword = keyword;
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

        [HttpPost]
        public IActionResult Assign(PersonnelAssignViewModel model)
        {
            var taskToUpdate = _taskService.GetById(model.TaskId);
            taskToUpdate.AppUserId = model.PersonnelId;
            _taskService.Update(taskToUpdate);

            return RedirectToAction("Index");
        }

        public IActionResult PersonnelAssign(PersonnelAssignViewModel model)
        {
            TempData["Active"] = "taskOrder";
            var user = _userManager.Users.FirstOrDefault(I => I.Id == model.PersonnelId);
            var task = _taskService.GetTaskByIdWithUrgency(model.TaskId);

            PersonnelAssignListViewModel viewModel = new PersonnelAssignListViewModel()
            {
                AppUser = new AppUserListViewModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    SurName = user.SurName,
                    Picture = user.Picture
                },
                Task = new TaskListViewModel()
                {
                    Id = task.Id,
                    Name = task.Name,
                    Description = task.Description,
                    Urgency = task.Urgency
                }
            };

            return View(viewModel);
        }

        public IActionResult ShowDetails(int id)
        {
            TempData["Active"] = "taskOrder";
            var task = _taskService.GetTaskByIdWithReportsAndUser(id);
            AllTasksListViewModel model = new AllTasksListViewModel()
            {
                Name = task.Name,
                Description = task.Description,
                Report = task.Report,
                AppUser = task.AppUser
            };

            return View(model);
        }
    }
}
