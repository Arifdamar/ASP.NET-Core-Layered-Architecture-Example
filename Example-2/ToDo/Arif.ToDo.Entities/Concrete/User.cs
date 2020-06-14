using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Arif.ToDo.Entities.Interfaces;

namespace Arif.ToDo.Entities.Concrete
{
    public class User : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }

        public List<Work> Works { get; set; }
    }
}
