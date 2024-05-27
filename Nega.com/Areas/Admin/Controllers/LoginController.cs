using BE;
using BLL.Concrate;
using DAL.Context;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Negacom.Areas.Admin.Models;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Negacom.Areas.Admin.Controllers
{



    [Area("Admin")]
    public class LoginController : Controller
    {
        DB db = new DB();
        UserManegerloc _UserMangerbll = new UserManegerloc(new EFUserRepository());
        private readonly SignInManager<User> _signinmanager;

        public LoginController(SignInManager<User> signinmanager)
        {
            _signinmanager = signinmanager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignin u)
        {
            if (u.UserName == null || u.Password == null)
            {
                if (u.UserName == null)
                {
                    ModelState.AddModelError("", "connot be left blank the Emial");
                }
                if (u.Password == null)
                {
                    ModelState.AddModelError("", "connot be left blank the Password");
                }
                return View(u);
            }
            else
            {
                var chack = db.users.Select(U => U.Id).FirstOrDefault();
                if (chack == 0)
                {
                    var result = await _signinmanager.PasswordSignInAsync(u.UserName, u.Password, true, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {

                    var val = _UserMangerbll.GetbayUsername(u.UserName);
                    if (val == null || val.Status == true)
                    {
                        var result = await _signinmanager.PasswordSignInAsync(u.UserName, u.Password, true, true);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Your account needs to be approved by admin");
                    }
                }
                return View();
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signinmanager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
