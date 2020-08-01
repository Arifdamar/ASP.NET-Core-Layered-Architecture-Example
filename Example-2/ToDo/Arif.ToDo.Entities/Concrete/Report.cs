using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Entities.Interfaces;

namespace Arif.ToDo.Entities.Concrete
{
    public class Report : ITable
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public string Description { get; set; }

        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
