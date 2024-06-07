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
    public class BlogManager : IBlogeService
    {
        IBlogDal _ıblogdal;

        public BlogManager(IBlogDal ıblogdal)
        {
            _ıblogdal = ıblogdal;
        }

        public void Add(Blog t)
        {
            _ıblogdal.Add(t);
        }

        public void Delete(Blog t)
        {
            _ıblogdal.Delete(t);
        }

        public List<Blog> GetAll()
        {
            return _ıblogdal.GetAll();
        }

        public Blog GetById(int id)
        {
            return _ıblogdal.GetBayId(id);

        }

        public List<Blog> ReadBlogsWhiteRel()
        {
            return _ıblogdal.ReadBlogsWhiteRel();
        }

        public Blog ReadBlogsWhiteRelById(int id)
        {
            return _ıblogdal.ReadBlogsWhiteRelById(id);
        }

        public void Update(Blog t)
        {
            _ıblogdal.Update(t);
        }
    }
}
