using BE;
using DAL.Abstract;
using DAL.Context;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFrameWork
{
    public class EFBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        DB db = new DB();
        public List<Blog> ReadBlogsWhiteRel()
        {
            var q = db.blogs.Include(o=>o.Category).Include(c=>c.User).ToList();
            if (q != null)
            {
                return q;
            }
            return null;
        }

        public Blog ReadBlogsWhiteRelById(int id)
        {
            var q = db.blogs.Include(o => o.Category).Include(c => c.User).Where(x=>x.id == id).FirstOrDefault();
            if (q != null)
            {
                return q;
            }
            return null;
        }
    }
}
