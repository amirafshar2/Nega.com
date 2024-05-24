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
    public class EFPortfolioRepository : GenericRepository<Portfolio>, IPortfolioDal
    {
        DB db = new DB();
        public List<Portfolio> getportfilobaycategory()
        {
            var val = db.portfolios.Include(x=> x.Portfoliocategory).ToList();
            return val;
        }

        public Portfolio getPortfoliobyid(int id)
        {
            var val = db.portfolios.Include(z=>z.Portfoliocategory).Where(x=>x.id == id).SingleOrDefault();
            if (val != null)
            {
                return val;
            }
            return null;    
        }

        public void Update1(Portfolio p, int id)
        {
            var q = db.portfolios.Where(x => x.id == id).FirstOrDefault();
            if (q != null)
            {
                q.Title = p.Title;
                q.Brand = p.Brand;
                q.Picture = p.Picture;
                q.Link = p.Link;
                q.Status  = p.Status;
                q.Date = p.Date;
                q.PortfolioCateoryid = p.PortfolioCateoryid;
                db.SaveChanges();
            }
        }
    }
}
