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
           _ıportfilodal.Add(t);
        }

        public void Delete(Portfolio t)
        {
            _ıportfilodal.Delete(t);
        }

        public List<Portfolio> GetAll()
        {
            return _ıportfilodal.GetAll();
        }

        public Portfolio GetById(int id)
        {
            return _ıportfilodal.GetBayId(id);
        }

        public Portfolio getPortfoliobyid(int id)
        {
            throw new NotImplementedException();
        }

        public Portfolio getPortfoliobyidwhitecategory(int id)
        {
           return _ıportfilodal.getPortfoliobyid(id);
        }

        public List<Portfolio> Porfoliobaycategory()
        {
            return _ıportfilodal.getportfilobaycategory();
        }

        public void Update(Portfolio t)
        {
            _ıportfilodal.Update(t);
        }

        public void Update1(Portfolio p, int id)
        {
            _ıportfilodal.Update1(p, id);
        }
    }
}
