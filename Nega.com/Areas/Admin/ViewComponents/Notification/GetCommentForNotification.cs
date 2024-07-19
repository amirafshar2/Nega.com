using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Negacom.Areas.Admin.ViewComponents.Notification
{
    public class GetCommentForNotification : ViewComponent
    {
        NotificationManager _notificaitonbll = new NotificationManager(new EFNotificationRepository());

        public IViewComponentResult Invoke()
        {
            var noti = _notificaitonbll.GetAll();
            noti.Reverse();
            noti = noti.Where(o=>o.Recipient=="Admin" && o.ReadStatus== false && o.Type=="Comment").ToList();
            return View(noti);
        }
    }
}
