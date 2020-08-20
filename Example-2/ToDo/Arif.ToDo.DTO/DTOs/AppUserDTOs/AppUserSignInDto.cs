using System;
using System.Collections.Generic;
using System.Text;

namespace Arif.ToDo.DTO.DTOs.AppUserDTOs
{
    public class AppUserSignInDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
