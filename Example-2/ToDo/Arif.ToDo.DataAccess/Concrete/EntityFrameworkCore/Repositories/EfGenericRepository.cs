using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Arif.ToDo.DataAccess.Interfaces;
using Arif.ToDo.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<Table> : IGenericDal<Table> where Table: class, ITable, new()
    {
        public void Save(Table table)
        {
            using var context = new TodoContext();
            context.Set<Table>().Add(table);
            context.SaveChanges();
        }

        public void Delete(Table table)
        {
            using var context = new TodoContext();
            context.Set<Table>().Remove(table);
            context.SaveChanges();
        }

        public void Update(Table table)
        {
            using var context = new TodoContext();
            context.Set<Table>().Update(table);
            context.SaveChanges();
        }

        public Table GetById(int id)
        {
            using var context = new TodoContext();
            return context.Set<Table>().Find(id);
        }

        public List<Table> GetAll()
        {
            using var context = new TodoContext();
            return context.Set<Table>().ToList();
        }
    }
}
