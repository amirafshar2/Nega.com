using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.ViewComponents.Portfolio
{
    public class GetPortfolio : ViewComponent
    {
        PortfolioManager _portfoliobll = new PortfolioManager(new EFPortfolioRepository());
        public IViewComponentResult Invoke()
        {
            var value = _portfoliobll.Porfoliobaycategory();
            return View(value);
        }
    }
}
