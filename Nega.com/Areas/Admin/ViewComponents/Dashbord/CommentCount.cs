using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Negacom.Areas.Admin.ViewComponents.Dashbord
{
    public class CommentCount : ViewComponent
    {
        CommentManager _commentbll = new CommentManager(new EFCommentRepository());
        public IViewComponentResult Invoke()
        {
            var comment = _commentbll.GetAll();
            return View(comment);
        }
    }
}
