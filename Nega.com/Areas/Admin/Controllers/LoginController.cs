using BE;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Negacom.Areas.Admin.Models;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Negacom.Areas.Admin.Controllers
{



    [Area("Admin")]
    public class LoginController : Controller
    {
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
            if (u.Email == null || u.Password == null)
            {
                if (u.Email == null)
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
                var result = await _signinmanager.PasswordSignInAsync(u.Email, u.Password, true, true);
                return RedirectToAction("Index","Admin/Home");
            }

        }
    }
}
