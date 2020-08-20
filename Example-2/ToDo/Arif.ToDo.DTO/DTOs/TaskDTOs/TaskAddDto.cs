using System;
using System.Collections.Generic;
using System.Text;

namespace Arif.ToDo.DTO.DTOs.TaskDTOs
{
    public class TaskAddDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UrgencyId { get; set; }
    }
}
