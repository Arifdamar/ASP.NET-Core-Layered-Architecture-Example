using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.DataAccess.Interfaces
{
    public interface IAppUserDal
    {
        List<AppUser> GetNonAdminUsers();
        List<AppUser> GetNonAdminUsers(string keyword, int activePage);
    }
}
