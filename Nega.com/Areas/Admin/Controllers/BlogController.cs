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
    public class BlogController : Controller
    {
        private readonly IWebHostEnvironment Environment;

        public BlogController(IWebHostEnvironment _envirorment)
        {
            Environment = _envirorment;
        }

        BlogManager _blogbll = new BlogManager(new EFBlogRepository());
        CategoryManager _categorybll = new CategoryManager(new EFCategoryRepository());
        [HttpGet]
        public IActionResult Index()
        {
            var cateories = _categorybll.GetAll();
            if (cateories != null)
            {
                ViewBag.category = new SelectList(cateories, "id", "Name");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Index(BlogModel p)
        {

            if (p.Name == null || p.Title == null || p.categoryid == 0 || p.Content == null || p.Picture == null)
            {
                if (p.Name == null)
                {
                    ModelState.AddModelError("Name", "لطفا نام پاکت را وارد کنید");

                }
                if (p.Title == null)
                {
                    ModelState.AddModelError("Title", "لطفا سرتیتر پاکت را وارد کنید");

                }
                if (p.categoryid == 0)
                {
                    ModelState.AddModelError("", "لطفا کاتگوری  را وارد کنید");

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
                Blog pa = new Blog();
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
                pa.Status = false;
                pa.CategoryId = p.categoryid;
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
                _blogbll.Add(pa);
                return View();
            }


            ModelState.Clear(); // Formu temizle

            // Yeni boş form için view'ı döndürmek
            return RedirectToAction("Index");
           
        }
    }
}
