using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Arif.ToDo.Entities.Interfaces;

namespace Arif.ToDo.Entities.Concrete
{
    public class Task : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CratedDate { get; set; } = DateTime.Now;

        public int UrgencyId { get; set; }
        public Urgency Urgency { get; set; }

        public List<Report> Report { get; set; }

        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
