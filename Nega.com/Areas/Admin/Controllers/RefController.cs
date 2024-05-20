using BE;
using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using Negacom.Areas.Admin.Models;

namespace Negacom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RefController : Controller
    {
        PortfolioManager _portfoliobll = new PortfolioManager( new EFPortfolioRepository());
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index(PortfolioMOdel p)
        {

            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            return View();
        }
        [HttpPost]
        public IActionResult Update(PortfolioMOdel p)
        {

            return View();
        }

    }
}
