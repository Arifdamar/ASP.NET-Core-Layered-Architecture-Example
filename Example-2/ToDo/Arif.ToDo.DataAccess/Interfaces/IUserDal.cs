using System.Collections.Generic;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.DataAccess.Interfaces
{
    public interface IUserDal
    {
        void Save(User table);
        void Delete(User table);
        void Update(User table);
        User GetById(int id);
        List<User> GetAll();
    }
}
