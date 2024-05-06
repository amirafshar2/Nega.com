using Microsoft.AspNetCore.Mvc;

namespace Nega.com.Controllers
{
    public class NegaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
