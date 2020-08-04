﻿using System;
using System.Collections.Generic;
using System.Linq;
using Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Arif.ToDo.DataAccess.Interfaces;
using Arif.ToDo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfTaskRepository : EfGenericRepository<Task>, ITaskDal
    {
        public List<Task> GetUndoneTasksWithUrgency()
        {
            using (var context = new TodoContext())
            {
                return context.Tasks.Include(I => I.Urgency)
                    .Where(I => !I.Status)
                    .OrderByDescending(I => I.CratedDate)
                    .ToList();
            }
        }
    }
}
