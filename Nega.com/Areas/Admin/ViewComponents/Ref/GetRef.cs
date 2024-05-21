
using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.Areas.Admin.ViewComponents.Ref
{
  
    
    
    public class GetRef : ViewComponent
    {
        PortfolioManager _portfoliobll = new PortfolioManager(new EFPortfolioRepository());
        public IViewComponentResult Invoke()
        {
            var value = _portfoliobll.Porfoliobaycategory();

            value.Reverse();
            return View(value);
        }
    }
}
