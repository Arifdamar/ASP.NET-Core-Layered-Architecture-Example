using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Arif.ToDo.Web.Models
{
    public class AppUserAddViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı gereklidir")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar")]
        public string ConfirmPassword { get; set; }

        [EmailAddress(ErrorMessage = "Geçersin Eposta Adresi")]
        [Required(ErrorMessage = "Email gereklidir")]
        [Display(Name = "Eposta")]
        public string Email { get; set; }

        [Required(ErrorMessage = "İsim gereklidir")]
        [Display(Name = "İsim")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyisim gereklidir")]
        [Display(Name = "Soyisim")]
        public string SurName { get; set; }
    }
}
