using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.DataAccess.Interfaces
{
    public interface IWorkDal
    {
        void SaveWork(Work work);
        void DeleteWork(Work work);
        void UpdateWork(Work work);
        Work GetWorkById(int id);
        List<Work> GetAllWorks();
    }
}
