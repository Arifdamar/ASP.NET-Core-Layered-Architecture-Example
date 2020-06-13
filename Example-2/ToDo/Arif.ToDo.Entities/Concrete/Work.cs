using System;
using Arif.ToDo.Entities.Interfaces;

namespace Arif.ToDo.Entities.Concrete
{
    public class Work : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CratedDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
