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
    public class UserManeger : IUserService
    {
        IUserDal _ıuserdal;

        public UserManeger(IUserDal ıuserdal)
        {
            _ıuserdal = ıuserdal;
        }

        public void Add(User t)
        {
            throw new NotImplementedException();
        }

        public void Delete(User t)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User t)
        {
            throw new NotImplementedException();
        }
    }
}
