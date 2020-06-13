using System.Collections.Generic;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.DataAccess.Interfaces
{
    public interface IWorkDal
    {
        void Save(Work table);
        void Delete(Work table);
        void Update(Work table);
        Work GetById(int id);
        List<Work> GetAll();
    }
}
