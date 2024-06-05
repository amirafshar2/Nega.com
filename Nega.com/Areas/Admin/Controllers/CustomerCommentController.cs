using BE;
using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Negacom.Areas.Admin.Models;
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
            if (c.NameSurName == null || c.Brand == null || c.Email == null || c.Content == null || c.Picture == null )
            {
                if (c.NameSurName == null)
                {
                    ModelState.AddModelError("", "NameSureName  cannot be left blank");
                }
                if (c.Brand == null)
                {
                    ModelState.AddModelError("", "Brand  cannot be left blank");
                }
                if (c.Email == null)
                {
                    ModelState.AddModelError("", " Email  cannot be left blank");
                }
                if (c.Content == null)
                {
                    ModelState.AddModelError("", "Content  cannot be left blank");
                }
                if (c.Picture == null)
                {
                    ModelState.AddModelError("", "Picture  cannot be left blank");
                }
                return View(c);
            }
            else
            {
                CustomerComment cc = new CustomerComment()
                {
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
                    cc.Picture = upf.upload(c.Picture);
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
        public IActionResult Delete(int id)
        {
            var val = _customercommnet.GetById(id);
            _customercommnet.Delete(val);
            return View("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            CustomerCommmentModel cc = new CustomerCommmentModel();
            var c = _customercommnet.GetById(id);
            if (c != null)
            {
                cc.id = c.id;
                cc.NameSurName = c.NameSurName;
                cc.Brand = c.Brand;
                cc.Picturestring = c.Picture;
                cc.Email = c.Email;
                cc.Content = c.Content;
                cc.Date = c.Date;
                cc.Status = c.Status;

            }
            return View(cc);
        }
        [HttpPost]
        public IActionResult Update(CustomerCommmentModel c)
        {
            if (c.NameSurName == null || c.Brand == null || c.Email == null || c.Content == null)
            {
                if (c.NameSurName == null)
                {
                    ModelState.AddModelError("", "NameSureName  cannot be left blank");
                }
                if (c.Brand == null)
                {
                    ModelState.AddModelError("", "Brand  cannot be left blank");
                }
                if (c.Email == null)
                {
                    ModelState.AddModelError("", " Email  cannot be left blank");
                }
                if (c.Content == null)
                {
                    ModelState.AddModelError("", "Content  cannot be left blank");
                }
                return View(c);
            }
            else
            {
                var cc = _customercommnet.GetById(c.id);


                cc.NameSurName = c.NameSurName;
                cc.Brand = c.Brand;
                cc.Email = c.Email;
                cc.Content = c.Content;
                cc.Date = DateTime.Now;
                cc.id = c.id;

                if (c.Picture != null)
                {
                    UploadFİle upf = new UploadFİle(Environment);
                    cc.Picture = upf.upload(c.Picture);
                }
                else
                {
                    var val = _customercommnet.GetById(c.id);
                    cc.Picture = val.Picture;
                    val = null;
                }
                _customercommnet.Update(cc);
                return View("Index");
            }
        }
    }

}

