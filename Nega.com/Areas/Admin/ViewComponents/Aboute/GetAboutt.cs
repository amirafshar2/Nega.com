using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Negacom.Areas.Admin.ViewComponents.Aboute
{



    [Authorize(Roles = "Admin,Moderator")]
    public class GetAboutt : ViewComponent
    {
        AbouteManeger _aboutebll = new AbouteManeger(new EFAbouteRepository());
        public IViewComponentResult Invoke()
        {
            var value= _aboutebll.GetAll();
            value.Reverse();
            
            return View(value);
        }
    }
}
