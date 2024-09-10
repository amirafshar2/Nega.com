using BE;
using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admin,Moderator,Writer")]

    [Area("Admin")]
    public class BlogCategoryController : Controller
    {
        CategoryManager _Categorybll = new CategoryManager(new EFCategoryRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Category c)
        {
            if (c.Name == null || c.Description == null)
            {
                if (c.Name == null)
                {
                    ModelState.AddModelError("", "name cannot be left blank");
                }
                if (c.Description == null)
                {
                    ModelState.AddModelError("", "Discription connot be left bland");
                }
                return View(c);
            }
            else
            {
                _Categorybll.Add(c);
                return View();
            }
        }
        [HttpPost]
        public IActionResult UpdateStatus(int id, bool status)
        {
            var comment = _Categorybll.GetById(id);
            if (comment != null)
            {
                comment.Status = status;
                _Categorybll.Update(comment);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var val = _Categorybll.GetById(id);
            return View(val);
        }
        [HttpPost]
        public IActionResult Update(Category c,int id)
        {
            if (c.Name == null || c.Description == null)
            {
                if (c.Name == null)
                {
                    ModelState.AddModelError("", "name cannot be left blank");
                }
                if (c.Description == null)
                {
                    ModelState.AddModelError("", "Discription connot be left bland");
                }
                return View(c);
            }
            else
            {
               
                _Categorybll.Update1(c,id);
                return View("Index");
            }
        }
        public IActionResult Delete(int id)
        {
            var val= _Categorybll.GetById(id);
            _Categorybll.Delete(val);
            return View("Index");
        }
    }
}
