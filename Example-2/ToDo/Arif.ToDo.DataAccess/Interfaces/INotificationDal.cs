﻿using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.DataAccess.Interfaces
{
    public interface INotificationDal : IGenericDal<Notification>
    {
        List<Notification> GetUnreadNotificationsById(int id);
        int GetUnreadNotificationCountByUserId(int userId);
    }
}
