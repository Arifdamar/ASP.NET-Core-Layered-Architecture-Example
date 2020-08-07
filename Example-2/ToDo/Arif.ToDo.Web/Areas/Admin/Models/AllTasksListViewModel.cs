using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.Web.Areas.Admin.Models
{
    public class AllTasksListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CratedDate { get; set; }
        public Urgency Urgency { get; set; }
        public List<Report> Report { get; set; }
        public AppUser AppUser { get; set; }
    }
}
