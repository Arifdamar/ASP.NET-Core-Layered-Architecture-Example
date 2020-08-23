using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arif.ToDo.DTO.DTOs.AppUserDTOs;
using Arif.ToDo.DTO.DTOs.NotificationDTOs;
using Arif.ToDo.DTO.DTOs.ReportDTOs;
using Arif.ToDo.DTO.DTOs.TaskDTOs;
using Arif.ToDo.DTO.DTOs.UrgencyDTOs;
using Arif.ToDo.Entities.Concrete;
using AutoMapper;
using Task = Arif.ToDo.Entities.Concrete.Task;

namespace Arif.ToDo.Web.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region AppUser-AppUserDto

            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();
            CreateMap<AppUserListDto, AppUser>();
            CreateMap<AppUser, AppUserListDto>();
            CreateMap<AppUserSignInDto, AppUser>();
            CreateMap<AppUser, AppUserSignInDto>();

            #endregion

            #region Notification-NotificationDto

            CreateMap<NotificationListDto, Notification>();
            CreateMap<Notification, NotificationListDto>();

            #endregion

            #region Report-ReportDto

            CreateMap<ReportAddDto, Report>();
            CreateMap<Report, ReportAddDto>();
            CreateMap<ReportUpdateDto, Report>();
            CreateMap<Report, ReportUpdateDto>();

            #endregion

            #region Task-TaskDto

            CreateMap<TaskAddDto, Task>();
            CreateMap<Task, TaskAddDto>();
            CreateMap<TaskListDto, Task>();
            CreateMap<Task, TaskListDto>();
            CreateMap<TaskListAllDto, Task>();
            CreateMap<Task, TaskListAllDto>();
            CreateMap<TaskUpdateDto, Task>();
            CreateMap<Task, TaskUpdateDto>();

            #endregion

            #region Urgency-UrgencyDto

            CreateMap<UrgencyAddDto, Urgency>();
            CreateMap<Urgency, UrgencyAddDto>();
            CreateMap<UrgencyUpdateDto, Urgency>();
            CreateMap<Urgency, UrgencyUpdateDto>();
            CreateMap<UrgencyListDto, Urgency>();
            CreateMap<Urgency, UrgencyListDto>();

            #endregion
        }
    }
}
