using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;

namespace Negacom.Areas.Admin.ViewComponents.Service
{





    public class GetServiceAll : ViewComponent
    {
        ServiceManager _servicebll = new ServiceManager(new EFServiceRepository());
        public IViewComponentResult Invoke()
        {
            var value = _servicebll.GetAll(); 
            return View(value);
        }
    }
}
