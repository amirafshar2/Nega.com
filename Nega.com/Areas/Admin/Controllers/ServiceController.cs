using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        ServiceManager _servicebll = new ServiceManager(new EFServiceRepository());
        public IActionResult Index()
        {
            var value= _servicebll.GetAll();
            return View(value);
        }
    }
}
