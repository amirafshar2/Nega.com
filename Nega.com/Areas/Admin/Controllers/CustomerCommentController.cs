using BE;
using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerCommentController : Controller
    {
        CustomerCommentManager _customercommnet = new CustomerCommentManager(new EFCustomerCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
    }
}
