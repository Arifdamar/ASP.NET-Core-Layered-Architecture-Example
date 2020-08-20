using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.DataAccess.Interfaces;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public List<AppUser> GetNonAdminUsers()
        {
            return _appUserDal.GetNonAdminUsers();
        }

        public List<AppUser> GetNonAdminUsers(out int totalPage, string keyword, int activePage = 1)
        {
            return _appUserDal.GetNonAdminUsers(out totalPage, keyword, activePage);
        }

        public List<DualHelper> GetTopTaskCompleterUsers()
        {
            return _appUserDal.GetTopTaskCompleterUsers();
        }

        public List<DualHelper> GetTopActiveTaskUsers()
        {
            return _appUserDal.GetTopActiveTaskUsers();
        }
    }
}
