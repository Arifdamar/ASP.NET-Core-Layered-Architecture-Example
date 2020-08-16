using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Arif.ToDo.Entities.Concrete
{
    public class AppUser : IdentityUser<int>, ITable
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Picture { get; set; } = "default.png";

        public List<Notification> Notifications { get; set; }
        public List<Task> Tasks { get; set; }
    }
}
