using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.Web.Areas.Admin.Models
{
    public class TaskListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CratedDate { get; set; }

        public int UrgencyId { get; set; }
        public Urgency Urgency { get; set; }
    }
}
