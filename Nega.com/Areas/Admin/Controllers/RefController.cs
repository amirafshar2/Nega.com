using BE;
using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Negacom.Areas.Admin.Models;
using System;

namespace Negacom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RefController : Controller
    {
        PortfolioManager _portfoliobll = new PortfolioManager( new EFPortfolioRepository());
        PortfolioCategoryManager _portfoliocategorybll = new PortfolioCategoryManager(new EFPortfoiloCategoryRepository());
        private readonly IWebHostEnvironment Environment;

        public RefController(IWebHostEnvironment _envirorment)
        {
            Environment = _envirorment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cateories = _portfoliocategorybll.GetAll();
            if (cateories!=null)
            {
                ViewBag.category = new SelectList(cateories, "id", "Name");
            }
           
            return View();
        }
        [HttpPost]
        public IActionResult Index(PortfolioMOdel p)
        {
            if (p.Title == null || p.Brand== null || p.Picture == null|| p.Link == null )
            {
                if (p.Title == null)
                {
                    ModelState.AddModelError("", "Connot Be Left Blank The Title");
                }
                if (p.Brand == null)
                {
                    ModelState.AddModelError("", "Connot Be Left Blak The Brand");
                }
                if (p.Picture == null)
                {
                    ModelState.AddModelError("", "Connot Be Left Blank The Picture");
                }
                if (p.Link == null)
                {
                    ModelState.AddModelError("", "Connot Be Left Blank The Link");
                }
                if (p.categoryid == 0)
                {
                    ModelState.AddModelError("", "Cannot Be Left Blank The Category");
                }
                return View(p);
            }
            else
            {
                Portfolio pp = new Portfolio();
                if (p.Picture!= null)
                {
                    UploadFİle upf = new UploadFİle(Environment);
                    pp.Picture = upf.upload(p.Picture);
                }
                pp.Title = p.Title;
                pp.Brand= p.Brand;
                pp.Status = true;
                pp.Date = DateTime.Now;
                pp.Link = p.Link;
                pp.PortfolioCateoryid =p.categoryid;
                _portfoliobll.Add(pp);

                ModelState.Clear(); // Formu temizle

                // Yeni boş form için view'ı döndürmek
                return RedirectToAction("Index");
            }
            
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


        public IActionResult Delete(int id)
        {

            return View();
        }
    }
}
