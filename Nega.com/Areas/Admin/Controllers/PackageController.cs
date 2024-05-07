using BE;
using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using Nega.com.Areas.Admin.Models;
using System;
using System.IO;

namespace Nega.com.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PackageController : Controller
    {
        PackageManager _PckageBLL = new PackageManager(new EFpackageRepository()); 
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(PackageModel p)
        {
            Package pa= new Package();
            if (p.Picture!= null)
            {
                var extantion = Path.GetExtension(p.Picture.FileName);
                var newimagename = Guid.NewGuid() + extantion;
                var Location = Path.Combine(Directory.GetCurrentDirectory(),"Packimg/", newimagename);
                var stram = new FileStream(Location, FileMode.Create);
                p.Picture.CopyTo(stram);
                pa.Picture = newimagename;
           
            }
            pa.Name = p.Name;
            pa.Title = p.Title;
            pa.Status = true;
            pa.Price = p.Price;
            pa.Content = p.Content;
            pa.Content2 = p.Content2;
            pa.Content3 = p.Content3;
            pa.Date = DateTime.Now;
            _PckageBLL.Add(pa);
            return View();
        }
    }
}
