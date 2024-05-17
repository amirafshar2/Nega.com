using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Negacom.ViewComponents.Video
{
    
    
    
 
    public class GetVİdeo : ViewComponent
    {
        VİdeoManager _videobll = new VİdeoManager (new EFVideoRepository());
        public IViewComponentResult Invoke()
        {
            var value = _videobll.GetAll();
            value.Reverse();
            value.FirstOrDefault();
            return View(value);
        }
    }
}
