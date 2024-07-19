using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Negacom.Areas.Admin.ViewComponents.Notification
{
    public class GetNewUserForNotification : ViewComponent
    {
        NotificationManager _notificationBLL = new NotificationManager(new EFNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var noti = _notificationBLL.GetAll();
            noti.Reverse();
            noti = noti.Where(o=>o.Title == "CreateUser"  && o.Type == "Create" && o.Recipient=="Admin" && (o.ReadStatus == false ||o.Type == "Registred" && o.Title == "Registred")).ToList();
            
            return View(noti);
        }
    }
}
