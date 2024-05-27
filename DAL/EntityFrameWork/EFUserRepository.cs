using BE;
using DAL.Abstract;
using DAL.Context;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFrameWork
{
    public class EFUserRepository : GenericRepository<User>, IUserDal
    {
        DB db=new DB();
        public User GetbayUsername(string Username)
        {
            var q = db.Users.Where(x=>x.UserName == Username).FirstOrDefault();
            if (q!=null)
            {
                return q;
            }
            return null;
        }
    }
}
