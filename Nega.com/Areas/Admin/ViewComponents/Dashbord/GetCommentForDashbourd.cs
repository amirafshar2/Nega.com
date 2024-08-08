using DAL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Negacom.Areas.Admin.ViewComponents.Dashbord
{
    public class GetCommentForDashbourd : ViewComponent
    {
        DB db = new DB();
        public IViewComponentResult Invoke()
        {
            var blogcommetn = db.comments.Include(x => x.user).Include(o => o.Blog).Include(u => u.replies).ToList();
            blogcommetn.Reverse();
            blogcommetn.Take(10);
            return View(blogcommetn);
        }
    }
}
