using BE;
using BLL.Concrate;
using DAL.Context;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Negacom.Areas.Admin.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Negacom.Areas.Admin.Controllers
{



    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IWebHostEnvironment Environment;
        private readonly UserManager<User> _userManager;
       
        
        BlogManager _blogbll = new BlogManager(new EFBlogRepository());
        CategoryManager _categorybll = new CategoryManager(new EFCategoryRepository());
        BLL.Concrate.UserManegerloc _userbll = new UserManegerloc(new EFUserRepository());

        public BlogController(IWebHostEnvironment environment, UserManager<User> userManager)
        {
            Environment = environment;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task< IActionResult> Index()
        {

            var user = await _userManager.GetUserAsync(User);
            TempData["UserName"] = user.Name;

            var userloc = _userbll.GetbayUsername(user.UserName);
            // Kullanıcının ID'sini al
            TempData["Userİd"] = userloc.Id;

            // Kullanıcının ID'sini al
          

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
                pa.Userid = p.userid;
                pa.Date = DateTime.Now;
                _blogbll.Add(pa);
                return View();
            }


            ModelState.Clear(); // Formu temizle

            // Yeni boş form için view'ı döndürmek
            return RedirectToAction("Index");
           
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var cateories = _categorybll.GetAll();
            if (cateories != null)
            {
                ViewBag.category = new SelectList(cateories, "id", "Name");
            }
            var b = _blogbll.GetById(id);
            BlogModel bm = new BlogModel()
            {
                id = b.id,
                Name=b.Name,
                Title=b.Title,
                Content=b.Content,
                strPicture=b.Picture,
                strPicture2=b.Picture2,
                strPicture3=b.Picture3,
                strPicture4=b.Picture4,
                strPicture5=b.Picture5,
                strPicture6=b.Picture6,
                strPicture7=b.Picture7,
                strPicture8=b.Picture8,
                strPicture9=b.Picture9,
                strPicture10=b.Picture10,
                Title2 = b.Title2,
                Title3 = b.Title3,
                Title4 = b.Title4,
                Title5 = b.Title5,
                Title6 = b.Title6,
                Title7 = b.Title7,
                Title8 = b.Title8,
                Title9 = b.Title9,
                Title10 = b.Title10,
                Content2=b.Content2,
                Content3=b.Content3,
                Content4=b.Content4,
                Content5=b.Content5,
                Content6=b.Content6,
                Content7=b.Content7,
                Content8=b.Content8,
                Content9=b.Content9,
                Content10=b.Content10
            };

            return View(bm);
        }
        [HttpPost]
        public IActionResult Update(BlogModel p,int id)
        {

            if (p.Name == null || p.Title == null  || p.Content == null )
            {
                if (p.Name == null)
                {
                    ModelState.AddModelError("Name", "لطفا نام بلاگ را وارد کنید");

                }
                if (p.Title == null)
                {
                    ModelState.AddModelError("Title", "لطفا سرتیتر بلاگ را وارد کنید");

                }
               

                if (p.Content == null)
                {
                    ModelState.AddModelError("Content", "لطفا توضیحات بلاگ را وارد کنید");

                }
              

                return View("Index");
            }
            else
            {
                Blog pa = _blogbll.GetById(p.id);
                
                if (p.Picture != null)
                {

                    UploadFİle upf = new UploadFİle(Environment);
                    pa.Picture = upf.upload(p.Picture);

                }
                else
                {
                    DB db = new DB();
                    var val = db.blogs.Where(x => x.id == id).FirstOrDefault();
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
                    var val = db.blogs.Where(x => x.id == id).FirstOrDefault();
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
                    var val = db.blogs.Where(x => x.id == id).FirstOrDefault();
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
                    var val = db.blogs.Where(x => x.id == id).FirstOrDefault();
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
                    var val = db.blogs.Where(x => x.id == id).FirstOrDefault();
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
                    var val = db.blogs.Where(x => x.id == id).FirstOrDefault();
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
                    var val = db.blogs.Where(x => x.id == id).FirstOrDefault();
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
                    var val = db.blogs.Where(x => x.id == id).FirstOrDefault();
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
                    var val = db.blogs.Where(x => x.id == id).FirstOrDefault();
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
                    var val = db.blogs.Where(x => x.id == id).FirstOrDefault();
                    pa.Picture10 = val.Picture10;

                }
                if (p.categoryid == 0 )
                {
                    DB db = new DB();
                    var val = db.blogs.Where(z => z.id == p.id).FirstOrDefault();
                    pa.CategoryId = val.CategoryId;
                }
                else
                {
                    pa.CategoryId = p.categoryid;
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

                _blogbll.Update(pa);
                return View("Index");
            }


            ModelState.Clear(); // Formu temizle

            // Yeni boş form için view'ı döndürmek
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                _blogbll.Delete(_blogbll.GetById(id));
                return View("Index");
            }

        }
        public IActionResult UpdateStatus(int id, bool status)
        {
            var comment = _blogbll.GetById(id);
            if (comment != null)
            {
                comment.Status = status;
                _blogbll.Update(comment);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}
