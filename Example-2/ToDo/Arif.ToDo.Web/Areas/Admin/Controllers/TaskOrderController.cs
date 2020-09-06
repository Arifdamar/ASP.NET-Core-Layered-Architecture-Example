using System;
using System.Collections.Generic;
using System.Linq;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.DTO.DTOs.AppUserDTOs;
using Arif.ToDo.DTO.DTOs.TaskDTOs;
using Arif.ToDo.Entities.Concrete;
using Arif.ToDo.Web.Consts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Arif.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    [Area(AreaNames.Admin)]
    public class TaskOrderController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly ITaskService _taskService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IFileService _fileService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public TaskOrderController(IAppUserService appUserService, ITaskService taskService, UserManager<AppUser> userManager, IFileService fileService, INotificationService notificationService, IMapper mapper)
        {
            _appUserService = appUserService;
            _taskService = taskService;
            _userManager = userManager;
            _fileService = fileService;
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["Active"] = ActivePage.TaskOrder;

            return View(_mapper.Map<List<TaskListAllDto>>(_taskService.GetAllTasksWithAllFields()));
        }

        public IActionResult Assign(int id, string keyword, int activePage = 1)
        {
            TempData["Active"] = ActivePage.TaskOrder;
            ViewBag.Personnel = _mapper.Map<List<AppUserListDto>>(_appUserService.GetNonAdminUsers(out var totalPage, keyword, activePage));
            ViewBag.ActivePage = activePage;
            ViewBag.TotalPages = totalPage;
            ViewBag.Keyword = keyword;

            return View(_mapper.Map<TaskListDto>(_taskService.GetTaskByIdWithUrgency(id)));
        }

        [HttpPost]
        public IActionResult Assign(PersonnelAssignDto model)
        {
            var taskToUpdate = _taskService.GetById(model.TaskId);
            taskToUpdate.AppUserId = model.PersonnelId;
            _taskService.Update(taskToUpdate);

            _notificationService.Save(new Notification()
            {
                AppUserId = model.PersonnelId,
                Description = $"{taskToUpdate.Name} Görevine Atandınız."
            });

            return RedirectToAction("Index");
        }

        public IActionResult PersonnelAssign(PersonnelAssignDto model)
        {
            TempData["Active"] = ActivePage.TaskOrder;

            return View(new PersonnelAssignListDto()
            {
                AppUser = _mapper.Map<AppUserListDto>(_userManager.Users.FirstOrDefault(I => I.Id == model.PersonnelId)),
                Task = _mapper.Map<TaskListDto>(_taskService.GetTaskByIdWithUrgency(model.TaskId))
            });
        }

        public IActionResult ShowDetails(int id)
        {
            TempData["Active"] = ActivePage.TaskOrder;

            return View(_mapper.Map<TaskListAllDto>(_taskService.GetTaskByIdWithReportsAndUser(id)));
        }

        public IActionResult ExportExcel(int id)
        {
            return File(_fileService.ExportExcel(_taskService.GetTaskByIdWithReportsAndUser(id).Report), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Guid.NewGuid() + ".xlsx");
        }

        public IActionResult ExportPdf(int id)
        {
            var path = _fileService.ExportPdf(_taskService.GetTaskByIdWithReportsAndUser(id).Report);

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}
