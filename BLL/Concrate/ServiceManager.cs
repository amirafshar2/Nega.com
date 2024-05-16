using BE;
using BLL.Abstract;
using DAL.Abstract;
using Newtonsoft.Json.Linq;
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
            _iservicedal.Add(t);
        }

        public void Delete(Services t)
        {
            _iservicedal.Delete(t);
        }

        public List<Services> GetAll()
        {
            var value = _iservicedal.GetAll();
            value.Reverse();
            return value;
        }

        public Services GetById(int id)
        {
            return _iservicedal.GetBayId(id);
        }

        public void Update(Services t)
        {
            _iservicedal.Update(t);
        }
    }
}
