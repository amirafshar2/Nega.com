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
    public class PortfolioCategoryManager : IPortfoiloCategoryService
    {
        IPortfolioCategoryDal _ıportfoliocategorydal;
     

        public PortfolioCategoryManager(IPortfolioCategoryDal ıportfoliocategorydal)
        {
            _ıportfoliocategorydal = ıportfoliocategorydal;
        }

        public void Add(PortfolioCateory t)
        {
           _ıportfoliocategorydal.Add(t);
        }

        public void chengeStatus(PortfolioCateory cateory)
        {
            throw new NotImplementedException();
        }

        public void Delete(PortfolioCateory t)
        {
           _ıportfoliocategorydal.Delete(t);
        }

        public List<PortfolioCateory> GetAll()
        {
           return _ıportfoliocategorydal.GetAll();
        }

        public PortfolioCateory GetById(int id)
        {
            return _ıportfoliocategorydal.GetBayId(id); 
        }

        public void Update(PortfolioCateory t)
        {
            _ıportfoliocategorydal.chengeStatus(t);
        }
    }
}
