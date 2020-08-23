using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.DTO.DTOs.TaskDTOs
{
    public class TaskListAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public Urgency Urgency { get; set; }
        public List<Report> Report { get; set; }
        public AppUser AppUser { get; set; }
    }
}
