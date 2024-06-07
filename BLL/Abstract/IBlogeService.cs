using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IBlogeService : IGenericServis<Blog>
    {
        List<Blog> ReadBlogsWhiteRel();
        Blog ReadBlogsWhiteRelById(int id);
    }
}
