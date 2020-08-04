using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Arif.ToDo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            TempData["Active"] = "task";

            return View();
        }
    }
}
