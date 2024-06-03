using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.Areas.Admin.ViewComponents.Role
{




    public class GetRole : ViewComponent
    {
        RoleManager _rolebll = new RoleManager(new EFUserRoleeRepository());
        public IViewComponentResult Invoke()
        {
            var val = _rolebll.GetAll();
            val.Reverse();
            return View(val);
        }
    }
}
