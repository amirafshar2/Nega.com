using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.Areas.Admin.ViewComponents.Comment
{





    public class GetCommet : ViewComponent
    {
        CustomerCommentManager _commentbll = new CustomerCommentManager(new EFCustomerCommentRepository());
        public IViewComponentResult Invoke()
        {
            var val = _commentbll.GetAll();
            val.Reverse();

            return View(val);
        }


    }
}
