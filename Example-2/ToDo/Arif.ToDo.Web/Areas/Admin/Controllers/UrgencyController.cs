using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.DTO.DTOs.UrgencyDTOs;
using Arif.ToDo.Entities.Concrete;
using Arif.ToDo.Web.Areas.Admin.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arif.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UrgencyController : Controller
    {
        private readonly IUrgencyService _urgencyService;
        private readonly IMapper _mapper;

        public UrgencyController(IUrgencyService urgencyService, IMapper mapper)
        {
            _urgencyService = urgencyService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["Active"] = "urgency";

            return View(_mapper.Map<List<UrgencyListDto>>(_urgencyService.GetAll()));
        }

        public IActionResult AddUrgency()
        {
            TempData["Active"] = "urgency";

            return View(new UrgencyAddDto());
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
            TempData["Active"] = "urgency";

            return View(_mapper.Map<UrgencyUpdateDto>(_urgencyService.GetById(id)));
        }

        [HttpPost]
        public IActionResult UpdateUrgency(UrgencyUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _urgencyService.Update(_mapper.Map<Urgency>(model));

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
