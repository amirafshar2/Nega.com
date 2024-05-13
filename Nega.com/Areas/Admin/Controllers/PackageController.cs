using BE;
using BLL.Concrate;
using BLL.ValidationRules;
using DAL.Context;
using DAL.EntityFrameWork;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Nega.com.Areas.Admin.Models;
using Negacom;
using System;

using System.IO;
using System.Linq;

namespace Nega.com.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PackageController : Controller
    {
      
        PackageManager _PckageBLL = new PackageManager(new EFpackageRepository());

        private readonly IWebHostEnvironment Environment;

        public PackageController(IWebHostEnvironment _envirorment)
        {
            Environment = _envirorment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(PackageModel p)
        {
            if (p.Name == null|| p.Title == null|| p.Price == 0|| p.Content == null|| p.Picture == null)
            {
                if (p.Name == null)
                {
                    ModelState.AddModelError("Name", "لطفا نام پاکت را وارد کنید");

                }
                if (p.Title == null)
                {
                    ModelState.AddModelError("Title", "لطفا سرتیتر پاکت را وارد کنید");

                }
                if (p.Price == 0)
                {
                    ModelState.AddModelError("Price", "لطفا قیمت پاکت را وارد کنید");

                }

                if (p.Content == null)
                {
                    ModelState.AddModelError("Content", "لطفا توضیحات پاکت را وارد کنید");

                }
                if (p.Picture == null)
                {
                    ModelState.AddModelError("Picture", "لطفا عکس پاکت را وارد کنید");

                }
                return View();
            }
            else
            {
                Package pa = new Package();
                if (p.Picture != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.Picture = upf.upload(p.Picture);

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
        int idd;
        [HttpGet]
        public IActionResult Update(int id)
        {
            idd =id;
            var value = _PckageBLL.GetById(id);
            ViewBag.Name = value.Name;
            ViewBag.Tit=value.Title;
            ViewBag.Price=value.Price;
            ViewBag.Content = value.Content;
            ViewBag.Pic = value.Picture;
            return View();
        }
        [HttpPost]
        public IActionResult Update(PackageModel p ,int id)
        {

            if (p.Name == null || p.Title == null || p.Price == 0 || p.Content == null )
            {
                if (p.Name == null)
                {
                    ModelState.AddModelError("Name", "لطفا نام پاکت را وارد کنید");

                }
                if (p.Title == null)
                {
                    ModelState.AddModelError("Title", "لطفا سرتیتر پاکت را وارد کنید");

                }
                if (p.Price == 0)
                {
                    ModelState.AddModelError("Price", "لطفا قیمت پاکت را وارد کنید");

                }

                if (p.Content == null)
                {
                    ModelState.AddModelError("Content", "لطفا توضیحات پاکت را وارد کنید");

                }
             
                return View();
            }
            else
            {
                Package pa = new Package();
                if (p.Picture != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.Picture = upf.upload(p.Picture);

                }
                else
                {
                    DB db = new DB();
                    var val = db.packages.Where(x=> x.id == id).FirstOrDefault();
                    pa.Picture = val.Picture;
                    
                }
                
                pa.id=id;
                pa.Name = p.Name;
                pa.Title = p.Title;
                pa.Status = true;
                pa.Price = p.Price;
                pa.Content = p.Content;
                pa.Content2 = p.Content2;
                pa.Content3 = p.Content3;
                pa.Date = DateTime.Now;
                _PckageBLL.Update(pa);
                return View("Index");
            }
            
        }
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                _PckageBLL.Delete(_PckageBLL.GetById(id));
                return View("Index");
            }
            
        }
   
    }
}
