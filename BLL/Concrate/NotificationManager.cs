using BE;
using BLL.Abstract;
using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrate
{
    public class NotificationManager : INoteficationService
    {
        INotificationDAL _INotificationDal;

        public NotificationManager(INotificationDAL ıNotificationDal)
        {
            _INotificationDal = ıNotificationDal;
        }

        public void Add(Notification t)
        {
           _INotificationDal.Add(t);
        }

        public void Delete(Notification t)
        {
            _INotificationDal.Delete(t);
        }

        public List<Notification> GetAll()
        {
            return _INotificationDal.GetAll();
        }

        public Notification GetById(int id)
        {
            return _INotificationDal.GetBayId(id);
        }

        public void Update(Notification t)
        {
            _INotificationDal.Update(t);
        }
    }
}
