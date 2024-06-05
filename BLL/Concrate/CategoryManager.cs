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
            _ıcategoeydal.Add(t);
        }

        public void Delete(Category t)
        {
            _ıcategoeydal.Delete(t);
        }

        public List<Category> GetAll()
        {
            return _ıcategoeydal.GetAll();
        }

        public Category GetById(int id)
        {
            return _ıcategoeydal.GetBayId(id);
        }

        public void Update(Category t)
        {
            _ıcategoeydal.Update(t);
        }

        public void Update1(Category c, int id)
        {
            _ıcategoeydal.Update1(c,id);
        }
    }
}
