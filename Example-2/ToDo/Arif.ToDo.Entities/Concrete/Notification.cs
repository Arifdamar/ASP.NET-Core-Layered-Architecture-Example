using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Entities.Interfaces;

namespace Arif.ToDo.Entities.Concrete
{
    public class Notification : ITable
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
