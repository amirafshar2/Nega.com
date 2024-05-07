using BE;
using Microsoft.AspNetCore.Mvc;

namespace Nega.com.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PackageController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Package p)
        {
            return View();
        }
    }
}
