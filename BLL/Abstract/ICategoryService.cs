using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface ICategoryService:IGenericServis<Category>
    {
      void Update1(Category c, int id);
    }
}
