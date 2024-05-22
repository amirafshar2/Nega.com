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
    }
}
