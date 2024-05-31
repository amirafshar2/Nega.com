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
    public class RoleManager : IRoleService
    {
        IRoleDAL _roledal;

        public RoleManager(IRoleDAL roledal)
        {
            _roledal = roledal;
        }

        public void Add(UserRolee t)
        {
            _roledal.Add(t);
        }

        public void Delete(UserRolee t)
        {
            _roledal.Delete(t);
        }

        public List<UserRolee> GetAll()
        {
            return _roledal.GetAll();
        }

        public UserRolee GetById(int id)
        {
            return _roledal.GetBayId(id);
        }

        public void Update(UserRolee t)
        {
            _roledal.Update(t);
        }
    }
}
