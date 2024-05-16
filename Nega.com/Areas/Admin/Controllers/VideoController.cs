using BE;
using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VideoController : Controller
    {
        VİdeoManager _videoBll= new VİdeoManager(new EFVideoRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Video v)
        {
            if (v.Title == null || v.Content == null || v.VideoLink == null)
            {
                if (v.Title == null)
                {
                    ModelState.AddModelError("Title", "Title cannot be left blank");
                }
                if (v.Content == null)
                {
                    ModelState.AddModelError("COntent", "Content cannot be left blank");
                }
                if (v.VideoLink == null)
                {
                    ModelState.AddModelError("VideoLink", "VideoLink cannot be left blank");
                }
                return View(v);
            }
            else
            {
                v.Status = true;
                _videoBll.Add(v);
                return View();
            }
          
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _videoBll.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(Video v)
        {
            if (v.Title == null || v.Content == null || v.VideoLink == null)
            {
                if (v.Title == null)
                {
                    ModelState.AddModelError("Title", "Title cannot be left blank");
                }
                if (v.Content == null)
                {
                    ModelState.AddModelError("COntent", "Content cannot be left blank");
                }
                if (v.VideoLink == null)
                {
                    ModelState.AddModelError("VideoLink", "VideoLink cannot be left blank");
                }
                return View(v);
            }
            else
            {
                _videoBll.Update(v);
                return View("Index");
            }

        }
        public IActionResult Delete(int id)
        {
            _videoBll.Delete(_videoBll.GetById(id));
            return View("Index");
        }
    }
}
