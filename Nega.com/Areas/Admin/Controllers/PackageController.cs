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
              
                if (p.Picture2 != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.Picture2 = upf.upload(p.Picture2);

                }
                else
                {
                    DB db = new DB();
                    var val = db.packages.Where(x => x.id == id).FirstOrDefault();
                    pa.Picture2 = val.Picture2;

                }
               
                if (p.Picture3 != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.Picture3 = upf.upload(p.Picture3);

                }
                else
                {
                    DB db = new DB();
                    var val = db.packages.Where(x => x.id == id).FirstOrDefault();
                    pa.Picture3 = val.Picture3;

                }
               
                if (p.Picture4 != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.Picture4 = upf.upload(p.Picture4);

                }
                else
                {
                    DB db = new DB();
                    var val = db.packages.Where(x => x.id == id).FirstOrDefault();
                    pa.Picture4 = val.Picture4;

                }
                ;
                if (p.Picture5 != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.Picture5 = upf.upload(p.Picture5);

                }
                else
                {
                    DB db = new DB();
                    var val = db.packages.Where(x => x.id == id).FirstOrDefault();
                    pa.Picture5 = val.Picture5;

                }
                if (p.Picture6 != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.Picture6 = upf.upload(p.Picture6);

                }
                else
                {
                    DB db = new DB();
                    var val = db.packages.Where(x => x.id == id).FirstOrDefault();
                    pa.Picture6 = val.Picture6;

                }
                if (p.Picture7 != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.Picture7 = upf.upload(p.Picture7);

                }
                else
                {
                    DB db = new DB();
                    var val = db.packages.Where(x => x.id == id).FirstOrDefault();
                    pa.Picture7 = val.Picture7;

                }
                if (p.Picture8 != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.Picture8 = upf.upload(p.Picture8);

                }
                else
                {
                    DB db = new DB();
                    var val = db.packages.Where(x => x.id == id).FirstOrDefault();
                    pa.Picture8 = val.Picture8;

                }
                if (p.Picture9 != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.Picture9 = upf.upload(p.Picture9);

                }
                else
                {
                    DB db = new DB();
                    var val = db.packages.Where(x => x.id == id).FirstOrDefault();
                    pa.Picture9 = val.Picture9;

                }
                if (p.Picture10 != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.Picture10 = upf.upload(p.Picture10);

                }
                else
                {
                    DB db = new DB();
                    var val = db.packages.Where(x => x.id == id).FirstOrDefault();
                    pa.Picture10 = val.Picture10;

                }
                pa.id=id;
                pa.Name = p.Name;
                pa.Title = p.Title;
                pa.Title2 = p.Title2;
                pa.Title3 = p.Title3;
                pa.Title4 = p.Title4;
                pa.Title5 = p.Title5;
                pa.Title6 = p.Title6;
                pa.Title7 = p.Title7;
                pa.Title8 = p.Title8;
                pa.Title9 = p.Title9;
                pa.Title10 = p.Title10;
                pa.Status = true;
                pa.Price = p.Price;
                pa.Content = p.Content;
                pa.Content2 = p.Content2;
                pa.Content3 = p.Content3;
                pa.Content4 = p.Content4;
                pa.Content5 = p.Content5;
                pa.Content6 = p.Content6;
                pa.Content7 = p.Content7;
                pa.Content8 = p.Content8;
                pa.Content9 = p.Content9;
                pa.Content10 = p.Content10;
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
