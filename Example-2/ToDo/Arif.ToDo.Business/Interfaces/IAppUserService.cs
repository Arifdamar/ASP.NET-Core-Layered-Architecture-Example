using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.Business.Interfaces
{
    public interface IAppUserService
    {
        List<AppUser> GetNonAdminUsers();
        List<AppUser> GetNonAdminUsers(string keyword, int activePage);
    }
}
