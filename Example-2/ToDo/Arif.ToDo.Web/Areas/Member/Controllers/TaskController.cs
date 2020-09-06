using System.Collections.Generic;
using System.Threading.Tasks;
using Arif.ToDo.Business.Interfaces;
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
    public class TaskController : BaseIdentityController
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;

        public TaskController(ITaskService taskService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int activePage = 1)
        {
            TempData["Active"] = ActivePage.Task;
            var user = await GetCurrentUser();
            var tasks = _mapper.Map<List<TaskListAllDto>>(_taskService.GetCompletedTasksWithAllFields(out var totalPage, user.Id, activePage));
            ViewBag.TotalPage = totalPage;
            ViewBag.ActivePage = activePage;

            return View(tasks);
        }
    }
}
