using BE;
using BLL.Concrate;
using DAL.Context;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Nega.com.Areas.Admin.Models;
using Negacom.Areas.Admin.Models;
using System;
using System.Linq;

namespace Negacom.Areas.Admin.Controllers
{

    [Authorize]

    [Area("Admin")]
    public class AbouteController : Controller
    {

        AbouteManeger _aboutbll = new    AbouteManeger (new EFAbouteRepository());
        private readonly IWebHostEnvironment Environment;

        public AbouteController(IWebHostEnvironment _envirorment)
        {
            Environment = _envirorment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AboutModel p)
        {
            if (p.Title1 == null || p.Name == null  || p.Content == null  || p.İmage1 == null )
            {
                if (p.Name == null)
                {
                    ModelState.AddModelError("Name", "name cannot be left blank");

                }
                if (p.Title1 == null)
                {
                    ModelState.AddModelError("Name", "Title1 cannot be left blank");

                }
              
                if (p.Content == null)
                {
                    ModelState.AddModelError("Name", "Content cannot be left blank");

                }
               
                if (p.İmage1 == null)
                {
                    ModelState.AddModelError("Name", "İmage1 cannot be left blank");

                }
               
                if (p.MapLocation == null)
                {
                    ModelState.AddModelError("Name", "MapLocation cannot be left blank");
                }
                return View(p);
            }
            else
            {
                About pa = new About();
                if (p.İmage1 != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.İmage1 = upf.upload(p.İmage1);

                }
                if (p.İmage2 != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.İmage2 = upf.upload(p.İmage2);

                }
                pa.Name= p.Name;
                pa.Title1= p.Title1;
                pa.Title2 = p.Title2;
                pa.Content = p.Content;
                pa.Content2 = p.Content2;
                pa.Status = true;
                pa.MapLocation = p.MapLocation;
                _aboutbll.Add(pa);

            }
                return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            
            var value = _aboutbll.GetById(id);
            ViewBag.Name = value.Name;
            ViewBag.Tit = value.Title1;
            ViewBag.Tit2 = value.Title2;
            ViewBag.Content = value.Content;
            ViewBag.Content2 = value.Content2;
            ViewBag.Pic = value.İmage1;
            ViewBag.Pic2 = value.İmage2;
            ViewBag.map = value.MapLocation;
          
            return View();
        }
        [HttpPost]
        public IActionResult Update(AboutModel p, int id)
        {

            if (p.Title1 == null || p.Name == null  || p.Content == null  || p.MapLocation == null)
            {
                if (p.Name == null)
                {
                    ModelState.AddModelError("Name", "name cannot be left blank");

                }
                if (p.Title1 == null)
                {
                    ModelState.AddModelError("Name", "Title1 cannot be left blank");

                }
               
                if (p.Content == null)
                {
                    ModelState.AddModelError("Name", "Content cannot be left blank");

                }
             
                
               
                if (p.MapLocation == null)
                {
                    ModelState.AddModelError("Name", "MapLocation cannot be left blank");
                }
                return View(p);
            }
            else
            {
                About pa = new About();
                if (p.İmage1 != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.İmage1 = upf.upload(p.İmage1);

                }
                else
                {
                    DB db = new DB();
                    var val = db.abouts.Where(x => x.id == id).FirstOrDefault();
                    pa.İmage1 = val.İmage1;

                }
                if (p.İmage2 != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.İmage2 = upf.upload(p.İmage2);

                }
                else
                {
                    DB db = new DB();
                    var val = db.abouts.Where(x => x.id == id).FirstOrDefault();
                    pa.İmage2 = val.İmage2;

                }
                pa.Name = p.Name;
                pa.Title1 = p.Title1;
                pa.Title2 = p.Title2;
                pa.Content = p.Content;
                pa.Content2 = p.Content2;
                pa.Status = true;
                pa.id = p.id;
                pa.MapLocation = p.MapLocation;
                _aboutbll.Update(pa);

            }
            return View("Index");

        }
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                _aboutbll.Delete(_aboutbll.GetById(id));
                return View("Index");
            }

        }
    }
}
