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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _ıcategoeydal;

        public CategoryManager(ICategoryDal ıcategoeydal)
        {
            _ıcategoeydal = ıcategoeydal;
        }

        public void Add(Category t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category t)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category t)
        {
            throw new NotImplementedException();
        }
    }
}
