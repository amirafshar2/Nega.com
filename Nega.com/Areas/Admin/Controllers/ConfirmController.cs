using BE;
using DAL.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Negacom.Areas.Admin.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Negacom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ConfirmController : Controller
    {
        private readonly UserManager<User> _userManager;

        public ConfirmController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        string email;
        [HttpGet]
        public IActionResult Index(int id)
        {
            email = TempData["mail"].ToString();
            ViewBag.Email = email;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ConfirmModel c)
        {
            DB db = new DB();
          
            var user = db.Users.Where(z => z.Email == c.Email).FirstOrDefault();
            if (user.ContorimCod == c.Confirm)
            {
                user.EmailConfirmed = true;
                db.SaveChanges();
                return RedirectToAction("Index", "Profile",user);
            }
            return View();
        }
    }
}
