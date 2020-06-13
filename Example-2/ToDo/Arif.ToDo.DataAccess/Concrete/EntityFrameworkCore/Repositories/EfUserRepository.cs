using System;
using System.Collections.Generic;
using Arif.ToDo.DataAccess.Interfaces;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfUserRepository : IUserDal
    {
        public void Save(User table)
        {
            throw new NotImplementedException();
        }

        public void Delete(User table)
        {
            throw new NotImplementedException();
        }

        public void Update(User table)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
