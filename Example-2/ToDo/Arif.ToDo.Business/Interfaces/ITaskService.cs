using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.Business.Interfaces
{
    public interface ITaskService : IGenericService<Task>
    {
        List<Task> GetUndoneTasksWithUrgency();
    }
}
