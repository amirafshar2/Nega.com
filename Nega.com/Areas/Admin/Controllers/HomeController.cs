using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Nega.com.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Moderator,Writer")]
    [Area("Admin")]
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
