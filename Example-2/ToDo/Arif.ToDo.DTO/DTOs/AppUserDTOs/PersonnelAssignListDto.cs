using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.DTO.DTOs.TaskDTOs;

namespace Arif.ToDo.DTO.DTOs.AppUserDTOs
{
    public class PersonnelAssignListDto
    {
        public TaskListDto Task { get; set; }
        public AppUserListDto AppUser { get; set; }
    }
}
