using DAL.Context;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Negacom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogCommentController : Controller
    {
        BLL.Concrate.CommentManager _commentbll = new BLL.Concrate.CommentManager( new EFCommentRepository());
        DB db = new DB();
        [HttpGet]
        public IActionResult Index()
        {
            var blogcommetn = db.comments.Include(x => x.user).Include(o => o.Blog).Include(u => u.replies).ToList();
            blogcommetn.Reverse();
            return View(blogcommetn);
        }
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                _commentbll.Delete(_commentbll.GetById(id));
                return RedirectToAction("Index");
            }

        }
        public IActionResult UpdateStatus(int id, bool status)
        {
            var comment = _commentbll.GetById(id);
            if (comment != null)
            {
                comment.Status = status;
                _commentbll.Update(comment);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}
