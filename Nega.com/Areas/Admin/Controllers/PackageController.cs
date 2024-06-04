using BE;
using BLL.Concrate;
using BLL.ValidationRules;
using DAL.Context;
using DAL.EntityFrameWork;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Nega.com.Areas.Admin.Models;
using Negacom;
using System;

using System.IO;
using System.Linq;

namespace Nega.com.Areas.Admin.Controllers
{
    [Authorize]
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
                if (p.Picture2 != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.Picture2 = upf.upload(p.Picture2);

                }
                if (p.Picture3 != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.Picture3 = upf.upload(p.Picture3);

                }
                if (p.Picture4 != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.Picture4 = upf.upload(p.Picture4);

                }
                if (p.Picture5 != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.Picture5 = upf.upload(p.Picture5);

                }
                if (p.Picture6 != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.Picture6 = upf.upload(p.Picture6);

                }
                if (p.Picture7 != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.Picture7 = upf.upload(p.Picture7);

                }
                if (p.Picture8 != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.Picture8 = upf.upload(p.Picture8);

                }
                if (p.Picture9 != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.Picture9 = upf.upload(p.Picture9);

                }
                if (p.Picture10 != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.Picture10 = upf.upload(p.Picture10);

                }
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
            ViewBag.Tit2=value.Title2;
            ViewBag.Tit3=value.Title3;
            ViewBag.Tit4=value.Title4;
            ViewBag.Tit5=value.Title5;
            ViewBag.Tit6=value.Title6;
            ViewBag.Tit7=value.Title7;
            ViewBag.Tit8=value.Title8;
            ViewBag.Tit9=value.Title9;
            ViewBag.Tit10=value.Title10;
            ViewBag.Price=value.Price;
            ViewBag.Content = value.Content;
            ViewBag.Pic = value.Picture;
            ViewBag.Pic2 = value.Picture2;
            ViewBag.Pic3 = value.Picture3;
            ViewBag.Pic4 = value.Picture4;
            ViewBag.Pic5 = value.Picture5;
            ViewBag.Pic6 = value.Picture6;
            ViewBag.Pic7 = value.Picture7;
            ViewBag.Pic8 = value.Picture8;
            ViewBag.Pic9 = value.Picture9;
            ViewBag.Pic10 = value.Picture10;
            ViewBag.content2 = value.Content2;
            ViewBag.content3 = value.Content3;
            ViewBag.content4 = value.Content4;
            ViewBag.content5 = value.Content5;
            ViewBag.content6 = value.Content6;
            ViewBag.content7 = value.Content7;
            ViewBag.content8 = value.Content8;
            ViewBag.content9 = value.Content9;
            ViewBag.content10 = value.Content10;
            ViewBag.Status = value.Status;
            ViewBag.date = value.Date;
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
             
                return View("Index");
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
        public IActionResult UpdateStatus(int id, bool status)
        {
            var comment = _PckageBLL.GetById(id);
            if (comment != null)
            {
                comment.Status = status;
                _PckageBLL.Update(comment);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }


    }
}
