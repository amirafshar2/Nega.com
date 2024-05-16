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
           _ıvideodal.Add(t);
        }

        public void Delete(Video t)
        {
            _ıvideodal.Delete(t);
        }

        public List<Video> GetAll()
        {
            var value = _ıvideodal.GetAll();
            value.Reverse();
            return value;
        }

        public Video GetById(int id)
        {
            return _ıvideodal.GetBayId(id);
        }

        public void Update(Video t)
        {
            _ıvideodal.Update(t);
        }
    }
}
