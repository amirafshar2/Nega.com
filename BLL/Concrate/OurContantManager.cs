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
    public class OurContantManager : IOurContactService
    {
        IOurContactDal _ourcontantdal;

        public OurContantManager(IOurContactDal ourcontantdal)
        {
            _ourcontantdal = ourcontantdal;
        }

        public void Add(OurContact t)
        {
            throw new NotImplementedException();
        }

        public void Delete(OurContact t)
        {
            throw new NotImplementedException();
        }

        public List<OurContact> GetAll()
        {
            throw new NotImplementedException();
        }

        public OurContact GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(OurContact t)
        {
            throw new NotImplementedException();
        }
    }
}
