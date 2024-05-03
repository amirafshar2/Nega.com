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
    public class ServiceManager : İServiceService
    {
        IServiceDal _iservicedal;

        public ServiceManager(IServiceDal iservicedal)
        {
            _iservicedal = iservicedal;
        }

        public void Add(Services t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Services t)
        {
            throw new NotImplementedException();
        }

        public List<Services> GetAll()
        {
            throw new NotImplementedException();
        }

        public Services GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Services t)
        {
            throw new NotImplementedException();
        }
    }
}
