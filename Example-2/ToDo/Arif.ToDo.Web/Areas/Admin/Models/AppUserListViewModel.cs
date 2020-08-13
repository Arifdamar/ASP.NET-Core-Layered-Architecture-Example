using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Arif.ToDo.Web.Areas.Admin.Models
{
    public class AppUserListViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string Name { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        public string SurName { get; set; }

        [Display(Name = "E-Mail")]
        [EmailAddress(ErrorMessage = "Geçerli bir E-mail adresi giriniz")]
        public string Email { get; set; }

        [Display(Name = "Fotoğraf")]
        public string Picture { get; set; }
    }
}
