using BE;
using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.Controllers
{
    public class ComentController : Controller
    {
        CommentManager _commentbll = new CommentManager(new EFCommentRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateComment(Comment c)
        {
            
            return View();
        }
    }
}
