using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Negacom.Areas.Admin.ViewComponents.Notification
{

    public class GetContenctForNotification : ViewComponent
    {
        NotificationManager _NotificationBll = new NotificationManager(new EFNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var n = _NotificationBll.GetAll();
            n.Reverse();
            n = n.Where(o=> o.ReadStatus == false && o.Type == "request").ToList();
            return View(n);
        }
    }
}
