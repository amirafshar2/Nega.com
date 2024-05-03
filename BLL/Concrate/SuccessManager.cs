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
    public class SuccessManager : ISuccessService
    {
        ISuccessDal _ısuccessdal;

        public SuccessManager(ISuccessDal ısuccessdal)
        {
            _ısuccessdal = ısuccessdal;
        }

        public void Add(Success t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Success t)
        {
            throw new NotImplementedException();
        }

        public List<Success> GetAll()
        {
            throw new NotImplementedException();
        }

        public Success GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Success t)
        {
            throw new NotImplementedException();
        }
    }
}
