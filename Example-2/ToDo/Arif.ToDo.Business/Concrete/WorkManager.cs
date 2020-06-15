using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.Business.Concrete
{
    public class WorkManager : IWorkService
    {
        private readonly EfWorkRepository efWorkRepository;

        public WorkManager()
        {
            efWorkRepository = new EfWorkRepository();
        }
        public void Save(Work table)
        {
            efWorkRepository.Save(table);
        }

        public void Delete(Work table)
        {
            efWorkRepository.Delete(table);
        }

        public void Update(Work table)
        {
            efWorkRepository.Update(table);
        }

        public Work GetById(int id)
        {
            return efWorkRepository.GetById(id);
        }

        public List<Work> GetAll()
        {
            return efWorkRepository.GetAll();
        }
    }
}
