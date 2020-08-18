using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            using var context = new TodoContext();

            return context.Tasks.Include(I => I.Urgency)
                .Where(I => !I.Status)
                .OrderByDescending(I => I.CreatedDate)
                .ToList();
        }

        public List<Task> GetAllTasksWithAllFields()
        {
            using var context = new TodoContext();

            return context.Tasks
                .Include(I => I.Urgency)
                .Include(I => I.AppUser)
                .Include(I => I.Report)
                .Where(I => !I.Status)
                .OrderByDescending(I => I.CreatedDate)
                .ToList();
        }

        public List<Task> GetAllTasksWithAllFields(Expression<Func<Task, bool>> filter)
        {
            using var context = new TodoContext();

            return context.Tasks
                .Include(I => I.Urgency)
                .Include(I => I.AppUser)
                .Include(I => I.Report)
                .Where(filter)
                .OrderByDescending(I => I.CreatedDate)
                .ToList();
        }

        public List<Task> GetCompletedTasksWithAllFields(out int totalPage, int userId, int activePage = 1)
        {
            using var context = new TodoContext();

            var result = context.Tasks
                .Include(I => I.Urgency)
                .Include(I => I.AppUser)
                .Include(I => I.Report)
                .Where(I => I.AppUserId == userId)
                .Where(I => I.Status)
                .OrderByDescending(I => I.CreatedDate);

            totalPage = (int)Math.Ceiling((double)result.Count() / 3);
            var returnValue = result.Skip((activePage - 1) * 3).Take(3);

            return returnValue.ToList();
        }

        public Task GetTaskByIdWithUrgency(int id)
        {
            using var context = new TodoContext();

            return context.Tasks
                .Include(I => I.Urgency)
                .FirstOrDefault(I => !I.Status && I.Id == id);
        }

        public List<Task> GetByUserId(int userId)
        {
            using var context = new TodoContext();

            return context.Tasks
                .Where(I => I.AppUserId == userId)
                .ToList();
        }

        public Task GetTaskByIdWithReportsAndUser(int id)
        {
            using var context = new TodoContext();

            return context.Tasks
                .Include(I => I.Report)
                .Include(I => I.AppUser)
                .FirstOrDefault(I => I.Id == id);
        }

        public int GetCompletedTaskCountByUserId(int userId)
        {
            using var context = new TodoContext();

            return context.Tasks
                .Where(I => I.AppUserId == userId)
                .Count(I => I.Status);
        }
    }
}
