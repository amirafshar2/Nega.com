﻿using BLL.Concrate;
using DAL.Context;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Negacom.Areas.Admin.ViewComponents.Dashbord
{
    public class GetBlogListForDashbourd : ViewComponent
    {
        BlogManager _blogbll = new BlogManager(new EFBlogRepository());
        public IViewComponentResult Invoke()
        {
            DB db = new DB();
            List<BE.Blog> val = db.blogs.Include(x => x.Category).Include(o => o.User).ToList();
            val.Reverse();
            val.Take(10);
            return View(val);
        }
    }
}
