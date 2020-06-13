using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.DataAccess.Interfaces;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfWorkRepository : IWorkDal
    {
        public void SaveWork(Work work)
        {
            throw new NotImplementedException();
        }

        public void DeleteWork(Work work)
        {
            throw new NotImplementedException();
        }

        public void UpdateWork(Work work)
        {
            throw new NotImplementedException();
        }

        public Work GetWorkById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Work> GetAllWorks()
        {
            throw new NotImplementedException();
        }
    }
}
