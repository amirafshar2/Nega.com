using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.ViewComponents.Portfolio
{
    public class GetPortfolioCategory: ViewComponent
    {
        PortfolioCategoryManager _portfoliocategorybll =new PortfolioCategoryManager(new EFPortfoiloCategoryRepository());
        public IViewComponentResult Invoke()
        {
            var val= _portfoliocategorybll.GetAll();
            return View(val);
        }
    }
}
