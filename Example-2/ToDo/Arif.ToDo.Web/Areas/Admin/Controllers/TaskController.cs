using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Arif.ToDo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = "task";
            var tasks = _taskService.GetAll();
            List<TaskListViewModel> viewModel = new List<TaskListViewModel>();

            tasks.ForEach(task =>
            {
                viewModel.Add(new TaskListViewModel()
                {
                    Id = task.Id,
                    Name = task.Name,
                    Description = task.Description,
                    CratedDate = task.CratedDate,
                    Status = task.Status,
                    UrgencyId = task.UrgencyId,
                    Urgency = task.Urgency
                });
            });

            return View(viewModel);
        }
    }
}
