﻿using BE;
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
            _ıuserdal.Add(t);
        }

        public void Delete(User t)
        {
            _ıuserdal.Delete(t);
        }

        public List<User> GetAll()
        {
            return _ıuserdal.GetAll();
        }

        public User GetById(int id)
        {
            return _ıuserdal.GetBayId(id);
        }

        public void Update(User t)
        {
            _ıuserdal.Update(t);
        }
    }
}
