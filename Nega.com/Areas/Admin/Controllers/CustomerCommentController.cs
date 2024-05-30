using BE;
using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Negacom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerCommentController : Controller
    {
        private readonly IWebHostEnvironment Environment;

        public CustomerCommentController(IWebHostEnvironment _envirorment)
        {
            Environment = _envirorment;
        }
        CustomerCommentManager _customercommnet = new CustomerCommentManager(new EFCustomerCommentRepository());
        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Index(Models.CustomerCommmentModel c)
        {
            if (c.NameSurName == null || c.Brand == null|| c.Email == null || c.Content == null || c.Picture== null)
            {
                if (c.NameSurName == null)
                {
                    ModelState.AddModelError("", "connot be left bland the NameSureName");   
                }
                if (c.Brand == null)
                {
                    ModelState.AddModelError("", "connot be left bland the Brand");
                }
                if (c.Email == null )
                {
                    ModelState.AddModelError("", "connot be left bland the Email");
                }
                if (c.Content == null)
                {
                    ModelState.AddModelError("", "connot be left bland the Content");
                }
                if (c.Picture == null)
                {
                    ModelState.AddModelError("", "connot be left bland the Picture");
                }
                return View(c);
            }
            else
            {
                CustomerComment cc = new CustomerComment() {
                    NameSurName = c.NameSurName,
                    Brand = c.Brand,
                    Email = c.Email,
                    Content = c.Content,
                    Date = DateTime.Now,
                    Status = c.Status

                };
                if (c.Picture != null)
                {
                    UploadFİle upf = new UploadFİle(Environment);
                    cc.Picture= upf.upload(c.Picture);
                }
                _customercommnet.Add(cc);
            }
            return View();
        }
        [HttpPost]
        public IActionResult UpdateStatus(int id, bool status)
        {
            var comment = _customercommnet.GetById(id);
            if (comment != null)
            {
                comment.Status = status;
                _customercommnet.Update(comment);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}
