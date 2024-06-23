using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Negacom.Areas.Admin.ViewComponents.User
{




    public class GetUser :ViewComponent
    {
        UserManegerloc _Userbll = new UserManegerloc(new EFUserRepository());
        public IViewComponentResult Invoke()
        {
            var val = _Userbll.GetAll();
            val = val.Where(s=>s.DelateStatus== false).ToList();
            return View(val);
        }
    }
}
