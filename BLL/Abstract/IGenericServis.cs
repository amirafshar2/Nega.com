using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IGenericServis<T>
    {
        void Add(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetAll();
        T GetById(int id);
    }
}
