






using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.Areas.Admin.ViewComponents.GetPackage
{
    public class GetPackage : ViewComponent
    {
        PackageManager _packageBLL = new PackageManager(new EFpackageRepository());
        public IViewComponentResult Invoke()
        {
            var value = _packageBLL.GetAll();
            if (value != null)
            {
                return View(value);
            }
            else
            {
                return View();
            }
         
        }
    }
}
