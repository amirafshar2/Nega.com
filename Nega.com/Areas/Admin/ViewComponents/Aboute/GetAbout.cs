using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.Areas.Admin.ViewComponents.Aboute
{




    public class GetAbout : ViewComponent
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
