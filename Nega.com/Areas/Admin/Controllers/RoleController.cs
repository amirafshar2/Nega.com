using BE;
using BLL.Concrate;
using DAL.Context;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.Areas.Admin.Controllers
{





    [Area("Admin")]
    public class RoleController : Controller
    {
        DB db = new DB();
        RoleManager _rolebll = new RoleManager(new EFUserRoleeRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserRolee u)
        {
            if (u.Name == null)
            {
                ModelState.AddModelError("", "Connot be left bland the name");
                return View(u);
            }
            else
            {
                u.Status = true;
                _rolebll.Add(u);
                return View();
            }
        }
        [HttpPost]
        public IActionResult UpdateStatus(int id, bool status)
        {
            var comment = _rolebll.GetById(id);
            if (comment != null)
            {
                comment.Status = status;
                _rolebll.Update(comment);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}
