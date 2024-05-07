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
             _ıpackagedal.Add(t);
        }

        public void Delete(Package t)
        {
            _ıpackagedal.Delete(t);
        }

        public List<Package> GetAll()
        {
            return _ıpackagedal.GetAll();
        }

        public Package GetById(int id)
        {
            return _ıpackagedal.GetBayId(id);
        }

        public void Update(Package t)
        {
            _ıpackagedal.Update(t);
        }
    }
}
