using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.Web.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Arif.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    [Area(AreaNames.Admin)]
    public class GraphController : Controller
    {
        private readonly IAppUserService _appUserService;

        public GraphController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = ActivePage.Graph;

            return View();
        }

        public IActionResult TopCompleter()
        {
            var jsonString = JsonConvert.SerializeObject(_appUserService.GetTopTaskCompleterUsers());

            return Json(jsonString);
        }


        public IActionResult TopActiveTask()
        {
            var jsonString = JsonConvert.SerializeObject(_appUserService.GetTopActiveTaskUsers());

            return Json(jsonString);
        }
    }
}
