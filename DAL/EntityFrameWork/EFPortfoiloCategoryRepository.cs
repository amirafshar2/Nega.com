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
    public class EFPortfoiloCategoryRepository : GenericRepository<PortfolioCateory>, IPortfolioCategoryDal
    {
        DB db = new DB();
        public void chengeStatus(PortfolioCateory cateory)
        {
            var q= db.portfolioCateories.Where(x=> x.id==cateory.id).FirstOrDefault();
            if (q!=null)
            {
                q.Status = cateory.Status;
                db.SaveChanges();
            }
        }
    }
}
