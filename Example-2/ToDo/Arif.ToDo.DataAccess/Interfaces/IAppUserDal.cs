using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.DataAccess.Interfaces
{
    public interface IAppUserDal
    {
        List<AppUser> GetNonAdminUsers();
        List<AppUser> GetNonAdminUsers(out int totalPage, string keyword, int activePage);
        List<DualHelper> GetTopTaskCompleterUsers();
        List<DualHelper> GetTopActiveTaskUsers();
    }
}
