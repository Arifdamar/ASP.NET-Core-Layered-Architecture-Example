using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Arif.ToDo.Entities.Interfaces;

namespace Arif.ToDo.Entities.Concrete
{
    public class Work : ITable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        public DateTime CratedDate { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
