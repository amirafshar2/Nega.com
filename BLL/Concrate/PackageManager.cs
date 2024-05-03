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
    public class PackageManager : IPackageService
    {
        IPackageDal _ıpackagedal;

        public PackageManager(IPackageDal ıpackagedal)
        {
            _ıpackagedal = ıpackagedal;
        }

        public void Add(Package t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Package t)
        {
            throw new NotImplementedException();
        }

        public List<Package> GetAll()
        {
            throw new NotImplementedException();
        }

        public Package GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Package t)
        {
            throw new NotImplementedException();
        }
    }
}
