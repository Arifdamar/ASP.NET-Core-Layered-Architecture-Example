using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.DataAccess.Interfaces;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationRepository;

        public NotificationManager(INotificationDal notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public void Save(Notification table)
        {
            _notificationRepository.Save(table);
        }

        public void Delete(Notification table)
        {
            _notificationRepository.Delete(table);
        }

        public void Update(Notification table)
        {
            _notificationRepository.Update(table);
        }

        public Notification GetById(int id)
        {
            return _notificationRepository.GetById(id);
        }

        public List<Notification> GetAll()
        {
            return _notificationRepository.GetAll();
        }
    }
}
