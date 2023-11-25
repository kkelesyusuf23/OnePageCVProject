using CV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CV.Repositories
{
    public class GenericRepository<T> where T:class, new()
    {
        DBCvEntities dB = new DBCvEntities();
        public List<T> GetList()
        {
            return dB.Set<T>().ToList();
        }
        public void TAdd(T t)
        {
            dB.Set<T>().Add(t);
            dB.SaveChanges();
        }
        public void TDelete(T t)
        {
            dB.Set<T>().Remove(t);
            dB.SaveChanges();
        }
        public T TGet(int id)
        {
            return dB.Set<T>().Find(id);
        }
        public void TUpdate(T T)
        {
            dB.SaveChanges();
        }
        public T GetByID(Expression<Func<T,bool>> where)
        {
            return dB.Set<T>().FirstOrDefault(where);
        }
    }
}