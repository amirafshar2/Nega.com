using BE;
using BLL.Concrate;
using DAL.Context;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Http;
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
        private readonly UserManager<User> _usermanager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoginController(SignInManager<User> signinmanager, UserManager<User> usermanager, IHttpContextAccessor httpContextAccessor)
        {
            _signinmanager = signinmanager;
            _usermanager = usermanager;
            _httpContextAccessor = httpContextAccessor;
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
                    ModelState.AddModelError("", "Emial  connot be left blank");
                }
                if (u.Password == null)
                {
                    ModelState.AddModelError("", "Password connot be left blank");
                }
                return View(u);
            }
            else
            {
                var val = _UserMangerbll.GetbayUsername(u.UserName);
                if (val != null && await _usermanager.CheckPasswordAsync(  val, u.Password))
                {
                   

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
                return View(u);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signinmanager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
