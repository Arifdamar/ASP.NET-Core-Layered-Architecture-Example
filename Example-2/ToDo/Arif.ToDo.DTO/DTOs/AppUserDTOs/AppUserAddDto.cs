using System;
using System.Collections.Generic;
using System.Text;

namespace Arif.ToDo.DTO.DTOs.AppUserDTOs
{
    public class AppUserAddDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
