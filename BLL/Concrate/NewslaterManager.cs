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
    public class NewslaterManager : INewsLaterService
    {
        INewsLaterDal _ınewslaterdal;

        public NewslaterManager(INewsLaterDal ınewslaterdal)
        {
            _ınewslaterdal = ınewslaterdal;
        }

        public void Add(NewsLater t)
        {
            throw new NotImplementedException();
        }

        public void Delete(NewsLater t)
        {
            throw new NotImplementedException();
        }

        public List<NewsLater> GetAll()
        {
            throw new NotImplementedException();
        }

        public NewsLater GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(NewsLater t)
        {
            throw new NotImplementedException();
        }
    }
}
