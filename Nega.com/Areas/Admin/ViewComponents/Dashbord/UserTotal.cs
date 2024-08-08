using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BLL;
using BLL.Concrate;
using DAL.EntityFrameWork;
using System.Linq;
using System;

namespace Negacom.Areas.Admin.ViewComponents.Dashbord
{
    public class UserTotal : ViewComponent
    {
        UserManegerloc _userbll = new UserManegerloc(new EFUserRepository());
        public IViewComponentResult Invoke()
        {
            var user = _userbll.GetAll();
            user.Reverse();
            user = user.Where(o=>o.ReqesterDate.Year == DateTime.Now.Year).ToList();
           
            return View(user);
        }
    }
}
