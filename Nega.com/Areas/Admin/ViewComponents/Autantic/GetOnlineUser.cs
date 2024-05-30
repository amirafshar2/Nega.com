using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using Negacom.Areas.Admin.Models;
using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Authorization;
using DAL.Context;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Negacom.Areas.Admin.ViewComponents.Autantic
{


    public class GetOnlineUser : ViewComponent
    {
        private readonly UserManager<BE.User> _usermanager;

        public GetOnlineUser(UserManager<BE.User> usermanager)
        {
            _usermanager = usermanager;
        }

        public IViewComponentResult Invoke()
        {
            var username = HttpContext.User.Identity.Name;
            var user = new BE.User();
            // Oturum açmış kullanıcıyı kullanıcı adıyla al
            user = _usermanager.FindByNameAsync(username).Result;

            // Eğer kullanıcı yoksa veya oturum açmamışsa, null kontrolü yapılabilir
            if (user == null)
            {
                return View(null); // Null kontrolü
            }

            // Kullanıcı bilgilerini View'e geç
            return View("Default", user);
        }

    }

}
