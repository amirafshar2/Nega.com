using Microsoft.AspNetCore.Mvc;

namespace Nega.com.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PackageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
