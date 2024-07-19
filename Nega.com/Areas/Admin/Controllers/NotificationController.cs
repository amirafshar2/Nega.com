using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Negacom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NotificationController : Controller
    {
        NotificationManager _notificationbll = new NotificationManager(new EFNotificationRepository());

        public IActionResult Index()
        {
            var n = _notificationbll.GetAll();
            n.Reverse();
            n = n.Where(o => o.ReadStatus == false && o.Type == "request").ToList();
            return View(n);

        }
        public IActionResult NewUser()
        {
            var n = _notificationbll.GetAll();
            n.Reverse();
            n = n.Where(o => o.ReadStatus == false && (o.Type == "Create" || o.Type == "Registred")).ToList();
            return View(n);
        }
        public IActionResult NewComment()
        {
            var n = _notificationbll.GetAll();
            n.Reverse();
            n = n.Where(o => o.ReadStatus == false && o.Type == "Comment" ).ToList();
            return View(n);
        }
        [HttpPost]
        public IActionResult UpdateStatus(int id, bool status)
        {
            var comment = _notificationbll.GetById(id);
            if (comment != null)
            {
                comment.ReadStatus = status;
                _notificationbll.Update(comment);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

    }
}
