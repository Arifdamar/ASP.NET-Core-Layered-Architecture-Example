using System;
using System.Collections.Generic;
using System.Linq;
using Arif.ToDo.Entities.Concrete;
using Task = Arif.ToDo.Entities.Concrete.Task;

namespace Arif.ToDo.Web.Areas.Admin.Models
{
    public class PersonnelAssignListViewModel
    {
        public TaskListViewModel Task { get; set; }
        public AppUserListViewModel AppUser { get; set; }
    }
}
