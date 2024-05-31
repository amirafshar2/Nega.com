using BE;
using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using Negacom.Areas.Admin.Controllers;
using System.Linq;
using BE;
using System.Collections.Generic;

namespace Negacom.ViewComponents.CustomerComment
{
    public class GetCustomerComment :ViewComponent
    {
        CustomerCommentManager _custCommentbll = new CustomerCommentManager(new EFCustomerCommentRepository());

        
        public IViewComponentResult Invoke()
        {
            List<BE.CustomerComment> val = new List<BE.CustomerComment>();    
              var res =_custCommentbll.GetAll();
            foreach (var item in res)
            {
                if (item.Status == true)
                {
                    val.Add(item);
                }
            }
            val.Reverse();
            return View(val);
        }
    }
}
