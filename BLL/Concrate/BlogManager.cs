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
            throw new NotImplementedException();
        }

        public void Delete(Blog t)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetAll()
        {
            throw new NotImplementedException();
        }

        public Blog GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Blog t)
        {
            throw new NotImplementedException();
        }
    }
}
