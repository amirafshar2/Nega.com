using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.Areas.Admin.ViewComponents.Notif
{
    
    public class GetNotifications :  ViewComponent
    {
        NotificationManager _notificationbll = new NotificationManager(new EFNotificationRepository());
        public IViewComponentResult Invoke()
        {

            return View();
        }

    }
}
