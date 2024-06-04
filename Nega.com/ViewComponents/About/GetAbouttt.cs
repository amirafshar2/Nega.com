using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Negacom.ViewComponents.About
{




    public class GetAbouttt :ViewComponent
    {
        AbouteManeger _aboutbll = new AbouteManeger(new EFAbouteRepository());
        public IViewComponentResult Invoke()
        {
            var value= _aboutbll.GetAll();
            value.Reverse();
            value.FirstOrDefault();
            return View(value);
        }
    }
}
