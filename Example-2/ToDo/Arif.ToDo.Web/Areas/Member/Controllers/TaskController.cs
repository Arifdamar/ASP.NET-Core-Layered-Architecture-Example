using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.Entities.Concrete;
using Arif.ToDo.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Arif.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly UserManager<AppUser> _userManager;

        public TaskController(ITaskService taskService, UserManager<AppUser> userManager)
        {
            _taskService = taskService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int activePage = 1)
        {
            TempData["Active"] = "task";
            var user = await _userManager.FindByNameAsync(User.Identity.Name).ConfigureAwait(true);
            var tasks = _taskService.GetCompletedTasksWithAllFields(out var totalPage, user.Id, activePage);
            ViewBag.TotalPage = totalPage;
            ViewBag.ActivePage = activePage;
            List<AllTasksListViewModel> model = new List<AllTasksListViewModel>();

            tasks.ForEach(task =>
            {
                model.Add(new AllTasksListViewModel()
                {
                    Id = task.Id,
                    Name = task.Name,
                    Description = task.Description,
                    AppUser = task.AppUser,
                    CratedDate = task.CratedDate,
                    Report = task.Report,
                    Urgency = task.Urgency
                });
            });

            return View(model);
        }
    }
}
