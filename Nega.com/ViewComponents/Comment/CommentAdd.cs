using BE;
using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Negacom.ViewComponents.Comment
{
   
    public class CommentAdd:ViewComponent
    {
       
        CommentManager _commentbll = new CommentManager(new EFCommentRepository());

      

        [HttpGet]
        public IViewComponentResult Invoke(string b)
        {
            
            var val = _commentbll.GetCommentWithRelation(Convert.ToInt32(b));
            ViewBag.blogidd = Convert.ToInt32(b);
            return View(val);
        }
    }
}
