using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Negacom.Areas.Admin.ViewComponents.Video
{





    public class GetVideo : ViewComponent
    {
        VİdeoManager _Videobll = new VİdeoManager(new EFVideoRepository()); 
        public IViewComponentResult Invoke()
        {
            var value = _Videobll.GetAll();
            value.Reverse();
            value= value.Where(x=> x.Status== true).ToList();
            return View(value);

        }
    }
}
