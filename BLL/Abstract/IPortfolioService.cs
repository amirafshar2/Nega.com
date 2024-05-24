using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IPortfolioService: IGenericServis<Portfolio>
    {
        List<Portfolio> Porfoliobaycategory();
        Portfolio getPortfoliobyid(int id);
        void Update1(Portfolio p , int id);
    }
}
