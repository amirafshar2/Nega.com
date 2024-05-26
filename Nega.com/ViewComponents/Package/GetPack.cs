using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.ViewComponents.Package
{
    public class GetPack : ViewComponent
    {
        PackageManager _packagemanager = new PackageManager (new EFpackageRepository ());
        [HttpGet]
        public IViewComponentResult Invoke()
        {
            var valu =  _packagemanager.GetAll();
            return View(valu);
        }
    }
}
