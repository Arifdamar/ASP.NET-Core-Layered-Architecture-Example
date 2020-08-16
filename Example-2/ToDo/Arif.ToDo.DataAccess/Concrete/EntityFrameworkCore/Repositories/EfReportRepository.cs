﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Arif.ToDo.DataAccess.Interfaces;
using Arif.ToDo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfReportRepository : EfGenericRepository<Report>, IReportDal
    {
        public Report GetReportByIdWithTask(int id)
        {
            using var context = new TodoContext();

            return context.Reports
                .Include(I => I.Task)
                .FirstOrDefault(I => I.Id == id);
        }
    }
}
