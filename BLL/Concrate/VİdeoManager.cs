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
    public class VİdeoManager : IVideoService
    {
        IVideoDal _ıvideodal;

        public VİdeoManager(IVideoDal ıvideodal)
        {
            _ıvideodal = ıvideodal;
        }

        public void Add(Video t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Video t)
        {
            throw new NotImplementedException();
        }

        public List<Video> GetAll()
        {
            throw new NotImplementedException();
        }

        public Video GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Video t)
        {
            throw new NotImplementedException();
        }
    }
}
