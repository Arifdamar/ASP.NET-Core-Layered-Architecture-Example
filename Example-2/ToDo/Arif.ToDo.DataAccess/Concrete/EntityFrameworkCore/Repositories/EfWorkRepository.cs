using System;
using System.Collections.Generic;
using System.Linq;
using Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Arif.ToDo.DataAccess.Interfaces;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfWorkRepository : IWorkDal
    {
        public void Save(Work table)
        {
            using var context = new TodoContext();
            context.Works.Add(table);
            context.SaveChanges();
        }

        public void Delete(Work table)
        {
            using var context = new TodoContext();
            context.Works.Remove(table);
            context.SaveChanges();
        }

        public void Update(Work table)
        {
            using var context = new TodoContext();
            context.Works.Update(table);
            context.SaveChanges();
        }

        public Work GetById(int id)
        {
            using var context = new TodoContext();
            return context.Works.Find(id);
        }

        public List<Work> GetAll()
        {
            using var context = new TodoContext();
            return context.Works.ToList();
        }
    }
}
