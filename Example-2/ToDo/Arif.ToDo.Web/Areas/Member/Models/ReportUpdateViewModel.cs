using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Task = Arif.ToDo.Entities.Concrete.Task;

namespace Arif.ToDo.Web.Areas.Member.Models
{
    public class ReportUpdateViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Tanım")]
        [Required(ErrorMessage = "Tanım alanı boş geçilemez.")]
        public string Definition { get; set; }
        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "Açıklama alanı boş geçilemez.")]
        public string Description { get; set; }
        public Task Task { get; set; }
    }
}
