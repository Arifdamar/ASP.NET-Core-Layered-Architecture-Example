﻿using System;
using System.Collections.Generic;
using Arif.ToDo.DataAccess.Interfaces;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfWorkRepository : IWorkDal
    {
        public void Save(Work table)
        {
            throw new NotImplementedException();
        }

        public void Delete(Work table)
        {
            throw new NotImplementedException();
        }

        public void Update(Work table)
        {
            throw new NotImplementedException();
        }

        public Work GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Work> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
