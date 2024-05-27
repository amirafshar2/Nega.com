using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.Areas.Admin.ViewComponents.User
{




    public class GetUser :ViewComponent
    {
        UserManegerloc _Userbll = new UserManegerloc(new EFUserRepository());
        public IViewComponentResult Invoke()
        {
            var val = _Userbll.GetAll();
            return View(val);
        }
    }
}
