using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.Business.Interfaces
{
    public interface INotificationService : IGenericService<Notification>
    {
        List<Notification> GetUnreadNotificationsById(int id);
        int GetUnreadNotificationCountByUserId(int userId);
    }
}
