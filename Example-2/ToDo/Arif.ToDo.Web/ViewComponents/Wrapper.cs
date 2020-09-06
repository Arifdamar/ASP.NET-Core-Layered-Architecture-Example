using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.DTO.DTOs.AppUserDTOs;
using Arif.ToDo.Entities.Concrete;
using Arif.ToDo.Web.Consts;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
// ReSharper disable AsyncConverter.AsyncWait

namespace Arif.ToDo.Web.ViewComponents
{
    public class Wrapper : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public Wrapper(UserManager<AppUser> userManager, INotificationService notificationService, IMapper mapper)
        {
            _userManager = userManager;
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var user = _userManager.FindByNameAsync(User.Identity?.Name).Result;
            var model = _mapper.Map<AppUserListDto>(user);
            ViewBag.NotificationCount = _notificationService.GetUnreadNotificationsById(user.Id).Count;
            var roles = _userManager.GetRolesAsync(user).Result;

            if (roles.Contains(Roles.Admin))
            {
                return View(model);
            }

            return View("Member", model);
        }
    }
}
