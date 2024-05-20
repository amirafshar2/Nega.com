using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IGenericDal <T> where T : class
    {
        void Add(T item);

        void Delete(T item);
        void Update(T item);
        List<T> GetAll();
        T GetBayId(int id);
        List<T> GetAll(Expression<Func<T, bool>> filtre);
      
    }
}
