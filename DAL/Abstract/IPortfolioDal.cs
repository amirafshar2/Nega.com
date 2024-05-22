using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IPortfolioDal:IGenericDal<Portfolio>
    {
        List<Portfolio> getportfilobaycategory();
        Portfolio getPortfoliobyid(int id);
    }
}
