﻿using BE;
using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Negacom.Controllers
{
    public class ContectttController : Controller
    {
        ContactManager _contactbll = new ContactManager(new EFContactRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromBody] Contact c)
        {
            if (c.Mail == null || c.Subject == null || c.Message == null)
            {
                if (c.Mail == null)
                {
                    ModelState.AddModelError("", "Email cannot be left blank");
                }
                if (c.Subject == null)
                {
                    ModelState.AddModelError("", "Subject cannot be left blank");
                }
                if (c.Message == null)
                {
                    ModelState.AddModelError("", "Content cannot be left blank");
                }
            }

            if (ModelState.IsValid)
            {
                c.Date = DateTime.Now;
                c.Status = true;
                _contactbll.Add(c);
                return Json(new { success = true });
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, message = string.Join(", ", errors) });
        }
    }
}
