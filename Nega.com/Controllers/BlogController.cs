using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.Controllers
{
    public class BlogController : Controller
    {
        BlogManager _blogbll = new BlogManager(new EFBlogRepository());
        public IActionResult Index()
        {
            return View();
        }
    }
}
