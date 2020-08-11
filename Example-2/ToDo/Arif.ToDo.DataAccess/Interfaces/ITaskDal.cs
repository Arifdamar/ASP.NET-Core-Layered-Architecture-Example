using System.Collections.Generic;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.DataAccess.Interfaces
{
    public interface ITaskDal : IGenericDal<Task>
    {
        List<Task> GetUndoneTasksWithUrgency();
        List<Task> GetAllTasksWithAllFields();
        Task GetTaskByIdWithUrgency(int id);
        List<Task> GetByUserId(int userId);
        Task GetTaskByIdWithReportsAndUser(int id);
    }
}
