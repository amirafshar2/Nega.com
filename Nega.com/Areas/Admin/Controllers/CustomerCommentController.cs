using BE;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerCommentController : Controller
    {
        CustomerComment _customercommnet = new CustomerComment(new EFCustomerCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
    }
}
