using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Entity;

namespace CSBC.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Insert(T entity);
        void Delete(T entity);
        //IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetById(int id);
        void Update(T entity);
    }

}
