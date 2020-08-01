using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.Business.Concrete
{
    public class TaskManager : ITaskService
    {
        private readonly EfTaskRepository efWorkRepository;

        public TaskManager()
        {
            efWorkRepository = new EfTaskRepository();
        }
        public void Save(Task table)
        {
            efWorkRepository.Save(table);
        }

        public void Delete(Task table)
        {
            efWorkRepository.Delete(table);
        }

        public void Update(Task table)
        {
            efWorkRepository.Update(table);
        }

        public Task GetById(int id)
        {
            return efWorkRepository.GetById(id);
        }

        public List<Task> GetAll()
        {
            return efWorkRepository.GetAll();
        }
    }
}
