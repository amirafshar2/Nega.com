using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.Controllers
{


    public class BlogDetController : Controller
    {
        BlogManager _blogbll = new BlogManager(new EFBlogRepository());
        [HttpGet]
        public IActionResult Index(int id)
        {
            var val = _blogbll.ReadBlogsWhiteRelById(id);
            
            return View(val);
        }
    }
}
