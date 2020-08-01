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
        private readonly EfTaskRepository _workRepository;

        public TaskManager()
        {
            // TODO refactor
            _workRepository = new EfTaskRepository();
        }
        public void Save(Task table)
        {
            _workRepository.Save(table);
        }

        public void Delete(Task table)
        {
            _workRepository.Delete(table);
        }

        public void Update(Task table)
        {
            _workRepository.Update(table);
        }

        public Task GetById(int id)
        {
            return _workRepository.GetById(id);
        }

        public List<Task> GetAll()
        {
            return _workRepository.GetAll();
        }
    }
}
