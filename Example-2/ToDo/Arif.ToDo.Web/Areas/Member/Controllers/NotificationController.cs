using System.Collections.Generic;
using System.Threading.Tasks;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.DTO.DTOs.NotificationDTOs;
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
    public class NotificationController : BaseIdentityController
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = ActivePage.Notification;
            var user = await GetCurrentUser();

            return View(_mapper.Map<List<NotificationListDto>>(_notificationService.GetUnreadNotificationsById(user.Id)));
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            var notification = _notificationService.GetById(id);
            notification.Status = true;
            _notificationService.Update(notification);

            return RedirectToAction("Index");
        }
    }
}
