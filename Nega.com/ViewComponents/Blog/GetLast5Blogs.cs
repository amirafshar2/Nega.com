using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Negacom.ViewComponents.Blog
{





    public class GetLast5Blogs :ViewComponent
    {
            BlogManager _blogbll = new BlogManager(new EFBlogRepository());
        public IViewComponentResult Invoke()
        {
            var val = _blogbll.GetAll();
            val = val.Where(x=>x.Status== true).Take(5).ToList();
            return View(val);
        }
    }
}
