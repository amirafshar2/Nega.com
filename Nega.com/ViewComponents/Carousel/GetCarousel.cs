using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Nega.com.Areas.Admin.Controllers;

namespace Negacom.ViewComponents.Carousel
{





    public class GetCarousel : ViewComponent
    {
        PackageManager _Packagebll = new PackageManager(new EFpackageRepository());
        public IViewComponentResult Invoke()
        {
            var value = _Packagebll.GetAll();
            return View(value);
        }
    }
}
