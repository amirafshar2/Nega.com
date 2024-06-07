using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.ViewComponents.Contect
{


    public class AddContact : ViewComponent
    {
        ContactManager _contactbll = new ContactManager(new EFContactRepository());
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
