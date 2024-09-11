using Microsoft.AspNetCore.Mvc;

namespace Negacom.Controllers
{
    public class BlogListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
