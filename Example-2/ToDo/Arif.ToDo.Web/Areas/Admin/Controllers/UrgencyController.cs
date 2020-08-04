using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.Entities.Concrete;
using Arif.ToDo.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Arif.ToDo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UrgencyController : Controller
    {
        private readonly IUrgencyService _urgencyService;

        public UrgencyController(IUrgencyService urgencyService)
        {
            _urgencyService = urgencyService;
        }

        public IActionResult Index()
        {
            List<Urgency> urgencies = _urgencyService.GetAll();
            List<UrgencyListViewModel> viewModel = new List<UrgencyListViewModel>();

            urgencies.ForEach(urgency =>
            {
                viewModel.Add(new UrgencyListViewModel()
                {
                    Id = urgency.Id,
                    Definition = urgency.Description
                });
            });

            return View(viewModel);
        }

        public IActionResult AddUrgency()
        {
            return View(new AddUrgencyViewModel());
        }

        [HttpPost]
        public IActionResult AddUrgency(AddUrgencyViewModel model)
        {
            if (ModelState.IsValid)
            {
                _urgencyService.Save(new Urgency(){Description = model.Description});
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult UpdateUrgency(int id)
        {
            var urgency = _urgencyService.GetById(id);
            UpdateUrgencyViewModel model = new UpdateUrgencyViewModel()
            {
                Id = urgency.Id,
                Description = urgency.Description
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateUrgency(UpdateUrgencyViewModel model)
        {
            if (ModelState.IsValid)
            {
                _urgencyService.Update(new Urgency()
                {
                    Id = model.Id,
                    Description = model.Description
                });

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
