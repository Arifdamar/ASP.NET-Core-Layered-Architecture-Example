using System;
using System.Collections.Generic;
using System.Linq;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.DTO.DTOs.TaskDTOs;
using Arif.ToDo.Entities.Concrete;
using Arif.ToDo.Web.Areas.Admin.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Arif.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IUrgencyService _urgencyService;
        private readonly IMapper _mapper;

        public TaskController(ITaskService taskService, IUrgencyService urgencyService, IMapper mapper)
        {
            _taskService = taskService;
            _urgencyService = urgencyService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["Active"] = "task";

            return View(_mapper.Map<List<TaskListDto>>(_taskService.GetUndoneTasksWithUrgency()));
        }

        public IActionResult AddTask()
        {
            TempData["Active"] = "task";
            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Description");

            return View(new TaskAddDto());
        }

        [HttpPost]
        public IActionResult AddTask(TaskAddDto model)
        {
            if (ModelState.IsValid)
            {
                _taskService.Save(_mapper.Map<Task>(model));

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

            return View(_mapper.Map<TaskUpdateDto>(task));
        }

        [HttpPost]
        public IActionResult UpdateTask(TaskUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _taskService.Update(_mapper.Map<Task>(model));

                return RedirectToAction("Index");
            }

            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Description", model.UrgencyId);

            return View(model);
        }

        public IActionResult DeleteTask(int id)
        {
            _taskService.Delete(new Task() { Id = id });

            return Json(null);
        }
    }
}
