using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Negacom.ViewComponents.Comment
{
    public class GetBlogComments :ViewComponent
    {
        CommentManager _commentbll = new CommentManager(new EFCommentRepository());
        [HttpGet]
        public IViewComponentResult Invoke(int b)
        {
            var val = _commentbll.GetCommentWithRelation(Convert.ToInt32(b));
            
            return View(val);
        }

    }
}
