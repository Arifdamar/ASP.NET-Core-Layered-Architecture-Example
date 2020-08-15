using System;
using System.Collections.Generic;
using System.Linq;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arif.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class TaskOrderController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskOrderController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public IActionResult Index(int id)
        {
            TempData["Active"] = "taskOrder";
            var tasks = _taskService.GetAllTasksWithAllFields(I => I.AppUserId == id && !I.Status);

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
    }
}
