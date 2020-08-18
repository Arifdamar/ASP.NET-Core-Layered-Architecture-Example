using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Arif.ToDo.DataAccess.Interfaces;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfNotificationRepository : EfGenericRepository<Notification>, INotificationDal
    {
        public List<Notification> GetUnreadNotificationsById(int id)
        {
            using var context = new TodoContext();

            return context.Notifications
                .Where(I => I.AppUserId == id)
                .Where(I => !I.Status)
                .OrderByDescending(I => I.Id)
                .ToList();
        }
    }
}
