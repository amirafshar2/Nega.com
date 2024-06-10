using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Negacom.ViewComponents.Blog
{




    public class GetBlogCategory : ViewComponent
    {
        CategoryManager _vategorybll = new CategoryManager(new EFCategoryRepository());
        public IViewComponentResult Invoke()
        {
            var val = _vategorybll.GetAll();
            val = val.Where(u=>u.Status== true).ToList();
            return View(val);
        }
    }
}
