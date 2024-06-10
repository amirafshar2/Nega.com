using BE;
using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Negacom.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
  
    public class ContectController : Controller
    {
        ContactManager _contactbll = new ContactManager(new EFContactRepository());
        [HttpGet]
        public IActionResult Index()
        {
            var val = _contactbll.GetAll();
            var q = val.Where(z => z.Status == true);
            val.Reverse();
            return View(val);
        }

        [HttpPost]
        public IActionResult UpdateStatus(int id, bool status)
        {
            var comment = _contactbll.GetById(id);
            if (comment != null)
            {
                comment.Status = status;
                _contactbll.Update(comment);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}
