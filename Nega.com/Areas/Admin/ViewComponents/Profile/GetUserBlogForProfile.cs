using Microsoft.AspNetCore.Mvc;
using Negacom.Areas.Admin.Models;
using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Identity;
using BLL.Concrate;
using DAL.EntityFrameWork;
using System.Linq;

namespace Negacom.Areas.Admin.ViewComponents.Profile
{
    public class GetUserBlogForProfile : ViewComponent
    {
        UserManegerloc _userbll = new UserManegerloc(new EFUserRepository());
        BlogManager _belogbll = new BlogManager(new EFBlogRepository());

        public IViewComponentResult Invoke()
        {
            var user = HttpContext.User;
            if (user.Identity.IsAuthenticated)
            {
                // Kullanıcının kimlik doğrulama bilgileri alındı
                var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var uuser = _userbll.GetById(Convert.ToInt32(userId));
                // Örneğin, bu kimliği kullanarak kullanıcı verilerini veritabanından çekebilirsiniz
                var blogs = _belogbll.GetAll();
                blogs= blogs.Where(x=>x.Userid == uuser.Id ).ToList();
               
                return View(blogs);
            }
            else
            {
               
                return View("Index", "Login");

            }
           
        }
    }
}
