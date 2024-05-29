using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Negacom.Areas.Admin.Models;
using System;
using System.Security.Claims;
namespace Negacom.Areas.Admin.Controllers
{

    [Authorize]
    [Area("Admin")]
    public class ProfileController : Controller
    {
        UserManegerloc _userbll = new UserManegerloc(new EFUserRepository());

        public IActionResult Index()
        {
            var user = HttpContext.User;
            if (user.Identity.IsAuthenticated)
            {
                // Kullanıcının kimlik doğrulama bilgileri alındı
                var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var uuser = _userbll.GetById(Convert.ToInt32(userId));
                // Örneğin, bu kimliği kullanarak kullanıcı verilerini veritabanından çekebilirsiniz
                
                UserModel u = new UserModel() {
                    Name = uuser.Name,
                    Family = uuser.Family,
                    Id = uuser.Id,
                    Email = uuser.Email,
                    picstring = uuser.Picture,
                    PhoneNumber= uuser.PhoneNumber,
                    Adress=uuser.Address,
                    Status=uuser.Status,
                    StatusİnCompany=uuser.StatusİnCompany,
                    About=uuser.About,
                    Facebook=uuser.Facebook,
                    İnstagram=uuser.İnstagram,
                    Telegram=uuser.Telegram,
                    UserName=uuser.UserName

                };
                // Bu bilgileri bir View'e geçirerek Index sayfasını döndür
                return View(u);
            }
            else
            {
                // Kullanıcı kimliği doğrulanamadı, belki oturum açmamıştır
                // Bu duruma göre bir işlem yapılabilir, örneğin oturum açma sayfasına yönlendirilebilir
                return RedirectToAction("Index", "Login");
                
            }
        }
    }
}
