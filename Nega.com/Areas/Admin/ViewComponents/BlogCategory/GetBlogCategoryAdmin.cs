using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.Areas.Admin.ViewComponents.BlogCategory
{





    public class GetBlogCategoryAdmin : ViewComponent
    {
        CategoryManager _categorybll = new CategoryManager(new EFCategoryRepository()); 
        public IViewComponentResult Invoke()
        {
            var vale = _categorybll.GetAll();
            vale.Reverse();
            return View(vale);
        }
    }
}
