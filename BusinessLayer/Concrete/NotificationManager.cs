using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationServices
    {
        private readonly INotificationDal _notification;

        public NotificationManager(INotificationDal notification)
        {
            _notification = notification;
        }

        public void Add(Notification entity)
        {
            _notification.Add(entity);
        }

        public void Delete(Notification entity)
        {
            _notification.Delete(entity);
        }

        public Notification GetById(int id)
        {
            return _notification.GetById(x => x.Id == id);
        }

        public List<Notification> GetList()
        {
            return _notification.List();
        }

        public List<Notification> GetList(int id)
        {
            return _notification.List(x => x.Id == id);
        }

        public void Update(Notification entity)
        {
            _notification.Update(entity);
        }
    }
}
