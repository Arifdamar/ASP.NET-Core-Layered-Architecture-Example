using System;
using System.Collections.Generic;
using System.Linq;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.Entities.Concrete;
using Arif.ToDo.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Arif.ToDo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IUrgencyService _urgencyService;

        public TaskController(ITaskService taskService, IUrgencyService urgencyService)
        {
            _taskService = taskService;
            _urgencyService = urgencyService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = "task";
            var tasks = _taskService.GetUndoneTasksWithUrgency();
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

        public IActionResult AddTask()
        {
            TempData["Active"] = "task";
            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Description");

            return View(new AddTaskViewModel());
        }

        [HttpPost]
        public IActionResult AddTask(AddTaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                _taskService.Save(new Task()
                {
                    Name = model.Name,
                    Description = model.Description,
                    UrgencyId = model.UrgencyId
                });

                return RedirectToAction("Index");
            }

            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Description");

            return View(model);
        }

        public IActionResult UpdateTask(int id)
        {
            TempData["Active"] = "task";
            var task = _taskService.GetById(id);
            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Description", task.UrgencyId);

            return View(new UpdateTaskViewModel()
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                UrgencyId = task.UrgencyId
            });
        }

        [HttpPost]
        public IActionResult UpdateTask(UpdateTaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                _taskService.Update(new Task()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    UrgencyId = model.UrgencyId
                });

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult DeleteTask(int id)
        {
            _taskService.Delete(new Task() { Id = id });

            return Json(null);
        }
    }
}
