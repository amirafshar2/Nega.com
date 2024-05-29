using BE;
using BLL.Concrate;
using DAL.Context;
using DAL.EntityFrameWork;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Components;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging.Abstractions;
using MimeKit;
using Negacom.Areas.Admin.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Negacom.Areas.Admin.Controllers
{


    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment Environment;
        UserManegerloc _Userbll = new UserManegerloc(new EFUserRepository());

        public UserController(IPasswordHasher<User> passwordHasher, UserManager<User> userManager, IWebHostEnvironment _envirorment)
        {
            _passwordHasher = passwordHasher;
            _userManager = userManager;
            Environment = _envirorment;
        }


        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var val = _Userbll.GetAll();
            val.Reverse();
            return View(val);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index(UserModel u)
        {
            DB db = new DB();
            var emilcheck = db.users.Where(i => i.Email == u.Email).Select(x => x.Email).FirstOrDefault();
            if (emilcheck == null)
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
                        uu.About = u.About;
                        uu.Name = u.Name;
                        uu.Family = u.Family;
                        uu.Password = u.password;

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
            else
            {
                ModelState.AddModelError("", "your email has already been registered");
                return View();
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var val = _Userbll.GetById(id);
            if (val == null)
            {
                return NotFound();
            }
            ViewBag.id = val.Id;
            ViewBag.Name = val.Name;
            ViewBag.Family = val.Family;
            ViewBag.Email = val.Email;
            ViewBag.Picture = val.Picture;
            ViewBag.IDNumber = val.IdNumber;
            ViewBag.PhoneNumber = val.PhoneNumber;
            ViewBag.Adress = val.Address;
            ViewBag.Status = val.Status;
            ViewBag.StatusİnCompany = val.StatusİnCompany;
            ViewBag.About = val.About;
            ViewBag.Facebook = val.Facebook;
            ViewBag.İnstragram = val.İnstagram;
            ViewBag.Telegram = val.Telegram;
            ViewBag.UserName = val.UserName;

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update(UserModel u, int id)
        {
            if (u.Name == null || u.Family == null || u.UserName == null || u.Email == null || u.password == null)
            {
                if (u.Name == null) ModelState.AddModelError("", "Name cannot be left blank.");
                if (u.Family == null) ModelState.AddModelError("", "Family cannot be left blank.");
                if (u.UserName == null) ModelState.AddModelError("", "Username cannot be left blank.");
                if (u.Email == null) ModelState.AddModelError("", "Email cannot be left blank.");
                if (u.password == null) ModelState.AddModelError("", "Password cannot be left blank.");

                return View(u);
            }
            else
            {


                var existingUser = await _userManager.FindByIdAsync(id.ToString());
                if (existingUser == null)
                {
                    return NotFound();
                }

                if (u.password != u.Confirmpassword)
                {
                    ModelState.AddModelError("", "Password does not match the confirmation password.");
                    return View(u);
                }

                if (_userManager.Users.Any(i => i.Email == u.Email && i.Id != id))
                {
                    ModelState.AddModelError("", "Email is already in use.");
                    return View(u);
                }

                existingUser.Name = u.Name;
                existingUser.Family = u.Family;
                existingUser.UserName = u.UserName;
                existingUser.Email = u.Email;
                existingUser.About = u.About;
                existingUser.PhoneNumber = u.PhoneNumber;
                existingUser.Address = u.Adress;
                existingUser.Status = u.Status;
                existingUser.StatusİnCompany = u.StatusİnCompany;
                existingUser.Facebook = u.Facebook;
                existingUser.İnstagram = u.İnstagram;
                existingUser.Telegram = u.Telegram;
                existingUser.ReqesterDate = DateTime.Now;

                if (u.Picture != null)
                {
                    var uploadFile = new UploadFİle(Environment);
                    existingUser.Picture = uploadFile.upload(u.Picture);
                }

                // Parolayı hashleyin ve kaydedin
                existingUser.PasswordHash = _passwordHasher.HashPassword(existingUser, u.password);

                var result = await _userManager.UpdateAsync(existingUser);
                if (result.Succeeded)
                {
                    return View("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(u);
        }


        [HttpGet]
        public IActionResult Reqister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Reqister(UserSingModel u)
        {
            Random random = new Random();
            int ccode;
            ccode = random.Next(100000, 1000000);
            DB db = new DB();
            var emilcheck = db.users.Where(i => i.Email == u.Email).Select(x => x.Email).FirstOrDefault();
            if (emilcheck == null)
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

                        var chack = db.users.Select(U => U.Id).FirstOrDefault();
                        if (chack == 0)
                        {
                            uu.Status = true;
                        }
                        else
                        {
                            uu.Status = false;
                        }
                        uu.ContorimCod = ccode;
                        var resa = await _userManager.CreateAsync(uu, u.Password);

                        if (resa.Succeeded)
                        {
                            MimeMessage mime = new MimeMessage();
                            MailboxAddress mailboxAddressFrom = new MailboxAddress("Nega Admin", "afshar414amir@gmail.com");
                            MailboxAddress mailboxAddressto = new MailboxAddress("User", u.Email);
                            mime.From.Add(mailboxAddressFrom);
                            mime.To.Add(mailboxAddressto);
                            var bodybuilder = new BodyBuilder();
                            bodybuilder.TextBody = "Hello Dear " + u.Name + " " + u.SureName + " \n Your Confirmation code to register on Nega is" + ccode;
                            mime.Body = bodybuilder.ToMessageBody();
                            mime.Subject = "Nega Confirmation code ";
                            SmtpClient clint = new SmtpClient();
                            clint.Connect("smtp.gmail.com", 587, false);
                            clint.Authenticate("afshar414amir@gmail.com", "ievj jwvb piqf sfet");
                            clint.Send(mime);
                            clint.Disconnect(true);
                            TempData["mail"] = u.Email;
                            return RedirectToAction("Index", "Confirm");
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
            else
            {
                ModelState.AddModelError("", "your email has already been registered");
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            DB db = new DB();
            var q = db.users.Where(i => i.Id == id).FirstOrDefault();
            if (q != null)
            {
                q.Status = false;
                db.SaveChanges();
            }
            return View("Index");
        }
    }
}
