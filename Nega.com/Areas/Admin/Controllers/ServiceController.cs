using BE;
using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        ServiceManager _servicebll = new ServiceManager(new EFServiceRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Services s)
        {
            if (s.Title == null ||s.ICone == null || s.Content == null)
            {
                if (s.Title == null)
                {
                    ModelState.AddModelError("Name", "Title cannot be left blank");

                }
                if (s.ICone == null)
                {
                    ModelState.AddModelError("Title", "Icone cannot be left blank");

                }
                if (s.Content == null)
                {
                    ModelState.AddModelError("Price", "Content cannot be left blank");

                }

             
                return View();
            }
            else
            {
                s.Status = true;
                _servicebll.Add(s);
                return View();
            }
         
        }
        [HttpGet]
        public IActionResult Update(int id)
        {

           var value= _servicebll.GetById(id);
            return View(value); 
        }
        [HttpPost]
        public IActionResult Update(Services s)
        {
            if (s.Title == null || s.ICone == null || s.Content == null)
            {
                if (s.Title == null)
                {
                    ModelState.AddModelError("Name", "Title cannot be left blank");

                }
                if (s.ICone == null)
                {
                    ModelState.AddModelError("Title", "Icone cannot be left blank");

                }
                if (s.Content == null)
                {
                    ModelState.AddModelError("Price", "Content cannot be left blank");

                }


                return View("Index");
            }
            else
            {
                _servicebll.Update(s);
                return View("Index");
            }
               
        }
        public IActionResult Delete(int id)
        {
            _servicebll.Delete(_servicebll.GetById(id));
            return View("Index");
        }
    }
}
