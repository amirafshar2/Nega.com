using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.Areas.Admin.ViewComponents.Portfolio
{





    public class GetPortfolioAll : ViewComponent
    {
        PortfolioCategoryManager _categoryManager = new PortfolioCategoryManager(new EFPortfoiloCategoryRepository());
        public IViewComponentResult Invoke()
        {
            var value= _categoryManager.GetAll();
            value.Reverse();
            return View(value);
        }
    }
}
