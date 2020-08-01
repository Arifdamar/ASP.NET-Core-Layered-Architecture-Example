using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Entities.Interfaces;

namespace Arif.ToDo.Entities.Concrete
{
    public class Urgency : ITable
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public List<Task> Tasks { get; set; }
    }
}
