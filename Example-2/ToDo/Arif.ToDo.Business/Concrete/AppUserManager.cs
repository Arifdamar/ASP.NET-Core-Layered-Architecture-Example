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
    }
}
