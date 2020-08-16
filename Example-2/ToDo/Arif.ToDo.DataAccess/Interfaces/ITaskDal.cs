using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.DataAccess.Interfaces
{
    public interface ITaskDal : IGenericDal<Task>
    {
        List<Task> GetUndoneTasksWithUrgency();
        List<Task> GetAllTasksWithAllFields();
        List<Task> GetAllTasksWithAllFields(Expression<Func<Task, bool>> filter);
        List<Task> GetCompletedTasksWithAllFields(out int totalPage, int userId, int activePage);
        Task GetTaskByIdWithUrgency(int id);
        List<Task> GetByUserId(int userId);
        Task GetTaskByIdWithReportsAndUser(int id);
    }
}
