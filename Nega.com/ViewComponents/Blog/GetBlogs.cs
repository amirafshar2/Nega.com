using BLL.Concrate;
using DAL.Context;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Negacom.ViewComponents.Blog
{
    public class GetBlogs : ViewComponent
    {
        BlogManager _blogbll = new BlogManager(new EFBlogRepository());
        public IViewComponentResult Invoke()
        {
            DB dB = new DB();
            var val = dB.blogs.Include(x => x.Category).Include(o => o.User).ToList();
            val = val.Where(x => x.Status == true).ToList();
            val.Reverse();
            return View(val);
        }
    }
}
