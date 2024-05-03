using BE;
using BLL.Abstract;
using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrate
{
    public class PortfolioManager : IPortfolioService
    {
        IPortfolioDal _ıportfilodal;

        public PortfolioManager(IPortfolioDal ıportfilodal)
        {
            _ıportfilodal = ıportfilodal;
        }

        public void Add(Portfolio t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Portfolio t)
        {
            throw new NotImplementedException();
        }

        public List<Portfolio> GetAll()
        {
            throw new NotImplementedException();
        }

        public Portfolio GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Portfolio t)
        {
            throw new NotImplementedException();
        }
    }
}
