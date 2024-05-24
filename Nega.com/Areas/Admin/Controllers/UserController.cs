using BE;
using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Negacom.Areas.Admin.Models;
using System.Threading.Tasks;

namespace Negacom.Areas.Admin.Controllers
{


    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        
        UserManeger _Userbll = new UserManeger(new EFUserRepository());

        public UserController(UserManager<User> userManager)
        {
           _userManager = userManager;
          
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
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
                    var resa = await _userManager.CreateAsync(uu,u.Password);
                    if (resa.Succeeded)
                    {
                        return View("");
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
