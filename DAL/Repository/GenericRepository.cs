﻿using DAL.Abstract;
using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        DB db = new DB();
        public void Add(T item)
        {
            db.Add(item);
            db.SaveChanges();
        }

        public void Delete(T item)
        {
            if (item != null)
            {

                db.Remove(item);
            }
            db.SaveChanges();
        }

        public List<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filtre)
        {
            return db.Set<T>().Where(filtre).ToList();
        }

        public T GetBayId(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void Update(T item)
        {
            db.Update(item);
            db.SaveChanges();
        }


    }
}
