using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly EfUserRepository efUserRepository;

        public UserManager()
        {
            efUserRepository = new EfUserRepository();
        }
        public void Save(User table)
        {
            efUserRepository.Save(table);
        }

        public void Delete(User table)
        {
            efUserRepository.Delete(table);
        }

        public void Update(User table)
        {
            efUserRepository.Update(table);
        }

        public User GetById(int id)
        {
            return efUserRepository.GetById(id);
        }

        public List<User> GetAll()
        {
            return efUserRepository.GetAll();
        }
    }
}
