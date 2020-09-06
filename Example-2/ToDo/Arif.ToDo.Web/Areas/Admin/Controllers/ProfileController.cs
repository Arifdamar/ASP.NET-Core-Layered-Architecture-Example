using System;
using System.IO;
using System.Threading.Tasks;
using Arif.ToDo.DTO.DTOs.AppUserDTOs;
using Arif.ToDo.Entities.Concrete;
using Arif.ToDo.Web.BaseControllers;
using Arif.ToDo.Web.Consts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Arif.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    [Area(AreaNames.Admin)]
    public class ProfileController : BaseIdentityController
    {
        private readonly IMapper _mapper;

        public ProfileController(UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = ActivePage.Profile;

            return View(_mapper.Map<AppUserListDto>(await GetCurrentUser()));
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserListDto model, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                var userToUpdate = await UserManager.Users.FirstOrDefaultAsync(I => I.Id == model.Id);

                if (photo != null)
                {
                    string extension = Path.GetExtension(photo.FileName);
                    string photoName = Guid.NewGuid() + extension;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + photoName);
                    await using var stream = new FileStream(path, FileMode.Create);
                    await photo.CopyToAsync(stream);
                    userToUpdate.Picture = photoName;
                }

                userToUpdate.Name = model.Name;
                userToUpdate.SurName = model.SurName;
                userToUpdate.Email = model.Email;

                var result = await UserManager.UpdateAsync(userToUpdate);

                if (result.Succeeded)
                {
                    TempData["message"] = Messages.UpdateSuccessful;

                    return RedirectToAction("Index");
                }

                AddErrorRange(result.Errors);
            }

            return View(model);
        }
    }
}
