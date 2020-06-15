using System;
using System.Collections.Generic;
using System.Linq;
using Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Arif.ToDo.DataAccess.Interfaces;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfUserRepository : IUserDal
    {
        public void Save(User table)
        {
            using var context = new TodoContext();
            context.Users.Add(table);
            context.SaveChanges();
        }

        public void Delete(User table)
        {
            using var context = new TodoContext();
            context.Users.Remove(table);
            context.SaveChanges();
        }

        public void Update(User table)
        {
            using var context = new TodoContext();
            context.Users.Update(table);
            context.SaveChanges();
        }

        public User GetById(int id)
        {
            using var context = new TodoContext();
            return context.Users.Find(id);
        }

        public List<User> GetAll()
        {
            using var context = new TodoContext();
            return context.Users.ToList();
        }
    }
}
