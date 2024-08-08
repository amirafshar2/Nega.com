using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Negacom.Areas.Admin.ViewComponents.Dashbord
{
    public class BlogTotal : ViewComponent 
    {
        BlogManager _blogbll = new BlogManager(new EFBlogRepository());
        public IViewComponentResult Invoke()
        {
            var blog = _blogbll.GetAll();
            blog = blog.Where(c=> c.Status == true).ToList();
            return View(blog);
        }
    }
}
