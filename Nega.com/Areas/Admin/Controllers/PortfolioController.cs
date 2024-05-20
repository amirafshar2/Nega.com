using BE;
using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.Areas.Admin.Controllers
{



    [Area("Admin")]
    public class PortfolioController : Controller
    {
        PortfolioCategoryManager _portfoliobll = new PortfolioCategoryManager(new EFPortfoiloCategoryRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(PortfolioCateory p)
        {
            if (p.Name == null || p.Description == null)
            {
                ModelState.AddModelError("", "Name And Description cannot be left blank");
                return View(p);
            }
            else
            {
                p.Status = true;
                _portfoliobll.Add(p);
                return View();
            }

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var val = _portfoliobll.GetById(id);
            return View(val);
        }

        [HttpPost]
        public IActionResult Update(PortfolioCateory p)
        {
            if (p.Name == null || p.Description == null)
            {
                ModelState.AddModelError("", "Name And Description cannot be left blank");
                return View(p);
            }
            else
            {
                p.Status = true;
                _portfoliobll.Update(p);
                return View("Index");
            }

        }
        public IActionResult Delete(int id)
        {
            _portfoliobll.Delete(_portfoliobll.GetById(id));
            return View("Index");
        }
     


    }
}
