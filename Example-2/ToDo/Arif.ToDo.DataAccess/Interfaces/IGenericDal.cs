using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Entities.Interfaces;

namespace Arif.ToDo.DataAccess.Interfaces
{
    public interface IGenericDal<Table> where Table : class, ITable, new()
    {
        void Save(Table table);
        void Delete(Table table);
        void Update(Table table);
        Table GetById(int id);
        List<Table> GetAll();
    }
}
