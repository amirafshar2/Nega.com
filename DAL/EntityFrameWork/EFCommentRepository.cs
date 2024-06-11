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
    public class EFCommentRepository : GenericRepository<Comment>, ICommentDal
    {
        DB db = new DB();
        public List<Comment> GetCommentWithRelation(int Blogİd)
        {
            var q = db.comments.Include(x=>x.user).Include(o=>o.Blog).Where(u=>u.BlogId == Blogİd).ToList();
            if (q!=null)
            {
                return q;
            }
            return null;
        }
    }
}
