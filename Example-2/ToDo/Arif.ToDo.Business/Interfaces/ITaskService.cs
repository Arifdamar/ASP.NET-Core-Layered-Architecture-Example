﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.Business.Interfaces
{
    public interface ITaskService : IGenericService<Task>
    {
        List<Task> GetUndoneTasksWithUrgency();
        List<Task> GetAllTasksWithAllFields();
        List<Task> GetAllTasksWithAllFields(Expression<Func<Task, bool>> filter);
        List<Task> GetCompletedTasksWithAllFields(out int totalPage, int userId, int activePage = 1);
        Task GetTaskByIdWithUrgency(int id);
        List<Task> GetByUserId(int userId);
        Task GetTaskByIdWithReportsAndUser(int id);
        int GetCompletedTaskCountByUserId(int userId);
        int GetUndoneTaskCountByUserId(int userId);
        int GetUnassignedTaskCount();
        int GetCompletedTaskCount();
    }
}
