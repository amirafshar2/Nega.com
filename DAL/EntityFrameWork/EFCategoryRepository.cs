using BE;
using DAL.Abstract;
using DAL.Context;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFrameWork
{
    public class EFCategoryRepository : GenericRepository<Category>, ICategoryDal
    {
        DB db = new DB();
        public void Update1(Category c, int id)
        {
            var q= db.categories.Where(x=>x.id== id).FirstOrDefault();
            if (q != null)
            {
                q.Name= c.Name;
                q.Description = c.Description;
                q.Status = false;
                db.SaveChanges();
            }
        }
    }
}
