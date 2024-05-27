using BE;
using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging.Abstractions;
using Negacom.Areas.Admin.Models;
using System;
using System.Threading.Tasks;

namespace Negacom.Areas.Admin.Controllers
{


    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment Environment;
        UserManegerloc _Userbll = new UserManegerloc(new EFUserRepository());

        public UserController(UserManager<User> userManager, IWebHostEnvironment _envirorment)
        {
            _userManager = userManager;
            Environment = _envirorment;
        }



        [HttpGet]
        public IActionResult Index()
        {
            var val = _Userbll.GetAll();
            val.Reverse();
            return View(val);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserModel u)
        {
            if (u.Name == null || u.Family == null || u.UserName == null || u.Email == null || u.password == null || u.Picture == null)
            {
                if (u.Name == null)
                {
                    ModelState.AddModelError("", "connot be letf bland the Name");
                }
                if (u.Family == null)
                {
                    ModelState.AddModelError("", "connot be letf bland the Family");
                }
                if (u.UserName == null)
                {
                    ModelState.AddModelError("", "connot be letf bland the UserName");
                }
                if (u.Email == null)
                {
                    ModelState.AddModelError("", "connot be letf bland the Êmail");
                }
                if (u.password == null)
                {
                    ModelState.AddModelError("", "connot be letf bland the Password");
                }
                if (u.Picture == null)
                {
                    ModelState.AddModelError("", "connot be letf bland the Picture");
                }
                return View(u);
            }
            else
            {
                if (u.password == u.Confirmpassword)
                {
                    User uu = new User();
                    if (u.Picture != null)
                    {
                        UploadFİle upf = new UploadFİle(Environment);
                        uu.Picture = upf.upload(u.Picture);
                    }
                    uu.About=u.About;
                    uu.Name = u.Name;
                    uu.Family = u.Family;
                    uu.Password = u.password;
                    uu.IdNumber = u.IDNumber;
                    uu.PhoneNumber = u.PhoneNumber;
                    uu.Address = u.Adress;
                    uu.Status = u.Status;
                    uu.StatusİnCompany = u.StatusİnCompany;
                    uu.Facebook = u.Facebook;
                    uu.İnstagram = u.İnstagram;
                    uu.Telegram = u.Telegram;
                    uu.UserName = u.UserName;
                    uu.Email = u.Email;
                    uu.ReqesterDate = DateTime.Now;
                    var resa = await _userManager.CreateAsync(uu, u.password);
                    if (resa.Succeeded)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        foreach (var item in resa.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                        return View(u);
                    }

                }
                else
                {
                    ModelState.AddModelError("", "password does not match");
                    return View(u);
               
                }
                

            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var val = _Userbll.GetById(id);
            ViewBag.Name            = val.Name;
            ViewBag.Family          = val.Family;
            ViewBag.Email           = val.Email;
            ViewBag.Picture         = val.Picture;
            ViewBag.IDNumber        = val.IdNumber;
            ViewBag.PhoneNumber     = val.PhoneNumber;
            ViewBag.Adress          = val.Address;
            ViewBag.Status          = val.Status;
            ViewBag.StatusİnCompany = val.StatusİnCompany;
            ViewBag.About           = val.About;
            ViewBag.Facebook        = val.Facebook;
            ViewBag.İnstragram      = val.İnstagram;
            ViewBag.Telegram        = val.Telegram;
            ViewBag.UserName        = val.UserName;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserModel u , int id)
        {
            if (u.Name == null || u.Family == null || u.UserName == null || u.Email == null || u.password == null || u.Picture == null)
            {
                if (u.Name == null)
                {
                    ModelState.AddModelError("", "connot be letf bland the Name");
                }
                if (u.Family == null)
                {
                    ModelState.AddModelError("", "connot be letf bland the Family");
                }
                if (u.UserName == null)
                {
                    ModelState.AddModelError("", "connot be letf bland the UserName");
                }
                if (u.Email == null)
                {
                    ModelState.AddModelError("", "connot be letf bland the Êmail");
                }
                if (u.password == null)
                {
                    ModelState.AddModelError("", "connot be letf bland the Password");
                }
                if (u.Picture == null)
                {
                    ModelState.AddModelError("", "connot be letf bland the Picture");
                }
                return View(u);
            }
            else
            {
                if (u.password == u.Confirmpassword)
                {
                    User uu = new User();
                    if (u.Picture != null)
                    {
                        UploadFİle upf = new UploadFİle(Environment);
                        uu.Picture = upf.upload(u.Picture);
                    }
                    else
                    {
                        var val = _Userbll.GetById(id);
                        uu.Picture = val.Picture;
                    }
                    uu.About = u.About;
                    uu.Name = u.Name;
                    uu.Family = u.Family;
                    uu.Password = u.password;
                    uu.IdNumber = u.IDNumber;
                    uu.PhoneNumber = u.PhoneNumber;
                    uu.Address = u.Adress;
                    uu.Status = u.Status;
                    uu.StatusİnCompany = u.StatusİnCompany;
                    uu.Facebook = u.Facebook;
                    uu.İnstagram = u.İnstagram;
                    uu.PasswordHash = u.password;
                    uu.Telegram = u.Telegram;
                    uu.UserName = u.UserName;
                    uu.Email = u.Email;
                    uu.ReqesterDate = DateTime.Now;
                    var resa = await _userManager.UpdateAsync(uu);
                    if (resa.Succeeded)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        foreach (var item in resa.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                        return View(u);
                    }

                }
                else
                {
                    ModelState.AddModelError("", "password does not match");
                    return View(u);

                }
                return View();

            }
        }

        [HttpGet]
        public IActionResult Reqister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Reqister(UserSingModel u)
        {
            if (u.Password != u.ConfirmPassword)
            {
                ModelState.AddModelError("Confirm", "password repeat is wrong");
                return View(u);
            }
            else
            {

                if (u.Name == null || u.Email == null || u.Password == null || u.User == null || u.SureName == null)
                {
                    if (u.Name == null)
                    {
                        ModelState.AddModelError("Name", "connot be left bland the name");
                    }
                    if (u.SureName == null)
                    {
                        ModelState.AddModelError("SureName", "connot be left bland the surname");
                    }
                    if (u.Email == null)
                    {
                        ModelState.AddModelError("Email", "connot be left bland the email");
                    }
                    if (u.Password == null)
                    {
                        ModelState.AddModelError("Password", "connot be left bland the password");
                    }
                    if (u.ConfirmPassword == null)
                    {
                        ModelState.AddModelError("ConfirmPassword", "connot be left bland the password");
                    }
                    if (u.User == null)
                    {
                        ModelState.AddModelError("UserName", "connot be left bland the UserName");
                    }
                    return View(u);
                }
                else
                {
                    User uu = new BE.User()
                    {
                        Name = u.Name,
                        Family = u.SureName,
                        Email = u.Email,
                        UserName = u.User

                    };
                    uu.Status = false;
                    var resa = await _userManager.CreateAsync(uu, u.Password);
                    if (resa.Succeeded)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        foreach (var item in resa.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                        return View(u);
                    }

                }

            }

        }
    }
}
