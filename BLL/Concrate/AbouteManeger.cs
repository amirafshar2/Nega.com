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
    public class AbouteManeger : IAbouteService
    {
        IAbouteDal _aboutedal;

        public AbouteManeger(IAbouteDal aboutedal)
        {
            _aboutedal = aboutedal;
        }

        public void Add(About t)
        {
            _aboutedal.Add(t);
        }

        public void Delete(About t)
        {
            _aboutedal.Delete(t);
        }

        public List<About> GetAll()
        {
            return _aboutedal.GetAll();
        }

        public About GetById(int id)
        {
            return _aboutedal.GetBayId(id);
        }

        public void Update(About t)
        {
            _aboutedal.Update(t);
        }
    }
}
