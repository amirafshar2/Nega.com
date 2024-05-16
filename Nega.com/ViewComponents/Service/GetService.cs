using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.ViewComponents.Service
{
   
    
    
    
    
    public class GetService :ViewComponent
    {
        ServiceManager _serviceBLL = new ServiceManager(new EFServiceRepository());
        public IViewComponentResult Invoke()
        {
            var value = _serviceBLL.GetAll();
            value.Reverse();
            return View(value);
        }
    }
}
