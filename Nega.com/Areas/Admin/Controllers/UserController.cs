using BE;
using BLL.Concrate;
using DAL.Context;
using DAL.EntityFrameWork;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Components;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using MimeKit;
using Negacom.Areas.Admin.Models;
using System;
using System.Collections.Generic;
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
        private readonly RoleManager<UserRolee> _roleManager;
        UserManegerloc _Userbll = new UserManegerloc(new EFUserRepository());
        RoleManager _rolbll = new RoleManager(new EFUserRoleeRepository());
        NotificationManager _notificationbll = new NotificationManager(new EFNotificationRepository());

        public UserController(IPasswordHasher<User> passwordHasher, UserManager<User> userManager, IWebHostEnvironment environment, RoleManager<UserRolee> roleManager)
        {
            _passwordHasher = passwordHasher;
            _userManager = userManager;
            Environment = environment;
            _roleManager = roleManager;
        }

        [Authorize(Roles = "Admin,Moderator")]
        [HttpGet]
        public IActionResult Index()
        {
            var val = _Userbll.GetAll();
            val.Reverse();
            return View(val);
        }
        [Authorize(Roles = "Admin,Moderator")]
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
                        uu.DelateStatus = false;
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
                            var notif = new Notification() {
                            Title= "CreateUser",
                            Message= "Created new User , the User name is :"+uu.UserName ,
                            Timestamp= DateTime.Now,
                            Type= "Create",
                            Recipient = "Admin",
                            ReadStatus = false
                            };
                            _notificationbll.Add(notif);
                            return RedirectToAction("Index");
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
        [Authorize(Roles = "Admin,Moderator")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            HttpContext.Session.SetInt32("userid", id);
            var userId = HttpContext.Session.GetInt32("userid");
            var val = _Userbll.GetById((int)userId);
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

        [Authorize(Roles = "Admin,Moderator")]
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
                existingUser.DelateStatus = false;
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
                    return RedirectToAction("Index", "User");
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

            using (var db = new DB())
            {
                var emailCheck = db.users.FirstOrDefault(i => i.Email == u.Email || i.UserName == u.User);
                if (emailCheck != null)
                {
                    ModelState.AddModelError("", "Your email or username has already been registered.");
                    return View(u);
                }

                if (u.Password != u.ConfirmPassword)
                {
                    ModelState.AddModelError("Confirm", "Password confirmation does not match.");
                    return View(u);
                }

                if (string.IsNullOrWhiteSpace(u.Name) || string.IsNullOrWhiteSpace(u.SureName) ||
                    string.IsNullOrWhiteSpace(u.Email) || string.IsNullOrWhiteSpace(u.Password) ||
                    string.IsNullOrWhiteSpace(u.User) || string.IsNullOrWhiteSpace(u.ConfirmPassword))
                {
                    ModelState.AddModelError("", "All fields are required.");
                    return View(u);
                }

                User newUser = new User
                {
                    Name = u.Name,
                    Family = u.SureName,
                    Email = u.Email,
                    UserName = u.User,
                    ContorimCod = ccode

                };
                if (db.users.Any() == false)
                {
                    newUser.Status = true;


                    var createResult = await _userManager.CreateAsync(newUser, u.Password);
                    if (createResult.Succeeded)
                    {
                        UserRolee adminRole = new UserRolee { Name = "Admin", NormalizedName = "ADMIN", Status = true };
                        _rolbll.Add(adminRole);
                        UserRolee adminRole1 = new UserRolee { Name = "Moderator", NormalizedName = "MODERATOR", Status = true };
                        _rolbll.Add(adminRole1); 
                        UserRolee adminRole2 = new UserRolee { Name = "User", NormalizedName = "USER", Status = true };
                        _rolbll.Add(adminRole2);
                        UserRolee adminRole3 = new UserRolee { Name = "Writer", NormalizedName = "WRİTER", Status = true };
                        _rolbll.Add(adminRole3);
                        var user = await _userManager.FindByNameAsync(newUser.UserName);
                        var role = _rolbll.GetAll().FirstOrDefault(o => o.NormalizedName == adminRole.NormalizedName);

                        if (role != null)
                        {
                            // Detach role entity to prevent conflicts
                            db.Entry(role).State = EntityState.Detached;
                            await _userManager.AddToRoleAsync(user, role.NormalizedName);
                        }

                        MimeMessage mime = new MimeMessage();
                        mime.From.Add(new MailboxAddress("Nega Admin", "afshar414amir@gmail.com"));
                        mime.To.Add(new MailboxAddress("User", u.Email));
                        mime.Subject = "Nega Confirmation code";

                        var bodyBuilder = new BodyBuilder
                        {
                            TextBody = $"Hello Dear {u.Name} {u.SureName},\nYour Confirmation code to register on Nega is {ccode}"
                        };

                        mime.Body = bodyBuilder.ToMessageBody();

                        using (var client = new SmtpClient())
                        {
                            client.Connect("smtp.gmail.com", 587, false);
                            client.Authenticate("afshar414amir@gmail.com", "osgl jrbp yajb lbjq");
                            client.Send(mime);
                            client.Disconnect(true);
                        }

                        TempData["mail"] = u.Email;
                        return RedirectToAction("Index", "Confirm");
                    }
                    else
                    {
                        foreach (var error in createResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(u);
                    }
                }
                else
                {
                    newUser.Status = false;
                    var createResult = await _userManager.CreateAsync(newUser, u.Password);
                    if (createResult.Succeeded)
                    {

                        var notif = new Notification()
                        {
                            Title = "Registred",
                            Message = "Registred new User , the User name is :" + newUser.UserName,
                            Timestamp = DateTime.Now,
                            Type = "Registred",
                            Recipient = "Admin",
                            ReadStatus = false
                        };
                        _notificationbll.Add(notif);
                        MimeMessage mime = new MimeMessage();
                        mime.From.Add(new MailboxAddress("Nega Admin", "afshar414amir@gmail.com"));
                        mime.To.Add(new MailboxAddress("User", u.Email));
                        mime.Subject = "Nega Confirmation code";

                        var bodyBuilder = new BodyBuilder
                        {
                            TextBody = $"Hello Dear {u.Name} {u.SureName},\nYour Confirmation code to register on Nega is {ccode}"
                        };

                        mime.Body = bodyBuilder.ToMessageBody();

                        using (var client = new SmtpClient())
                        {
                            client.Connect("smtp.gmail.com", 587, false);
                            client.Authenticate("afshar414amir@gmail.com", "viva bduu ewvg dmph");
                            client.Send(mime);
                            client.Disconnect(true);
                        }

                        TempData["mail"] = u.Email;
                        return RedirectToAction("Index", "Confirm");
                    }
                    else
                    {
                        foreach (var error in createResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(u);
                    }
                }
            }
        }
        [Authorize(Roles = "Admin,Moderator")]
        [HttpPost]
        public IActionResult UpdateStatus(int id, bool status)
        {
            var comment = _Userbll.GetById(id);
            if (comment != null)
            {
                comment.Status = status;
                _Userbll.Update(comment);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [Authorize(Roles = "Admin,Moderator")]
        public IActionResult Delete(int id)
        {
            DB db = new DB();
            var q = db.users.Where(i => i.Id == id).FirstOrDefault();
            if (q != null)
            {
                q.Status = false;
                q.DelateStatus = true;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "User");
        }
        [Authorize(Roles = "Admin,Moderator")]
        public IActionResult UpdateStatus1(int id, bool status)
        {
            var comment = _Userbll.GetById(id);
            if (comment != null)
            {
                comment.Personeldurumu = status;
                _Userbll.Update(comment);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [Authorize(Roles = "Admin,Moderator")]
        [HttpGet]
        public async Task<IActionResult> AddRole(int id)
        {

            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();

            var userroles = await _userManager.GetRolesAsync(user);
            List<Rolemodel> rm = new List<Rolemodel>();
            foreach (var item in roles)
            {
                Rolemodel m = new Rolemodel();
                m.roleid = item.Id;
                TempData["userid"] = user.Id;
                m.name = item.Name;
                m.Username = user.UserName;
                m.Userid = user.Id;
                m.exist = userroles.Contains(item.Name);
                rm.Add(m);

            }

            return View(rm);
        }
        [Authorize(Roles = "Admin,Moderator")]
        [HttpPost]
        public async Task<IActionResult> AddRole(List<Rolemodel> m)
        {
            var userıd = (int)TempData["userid"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userıd);
            if (user == null)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {

                foreach (var item in m)
                {


                    if (item.exist)
                    {
                        var val = _rolbll.GetById(item.roleid);
                        await _userManager.AddToRoleAsync(user, val.NormalizedName);

                    }
                    else
                    {
                        var val = _rolbll.GetById(item.roleid);
                        await _userManager.RemoveFromRoleAsync(user, val.NormalizedName);

                    }
                }
            }

            return RedirectToAction("Index", "User");
        }
        public IActionResult Accessdenied ()
        {
            return View();
        }
    }


}


