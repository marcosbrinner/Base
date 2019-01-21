using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.IRepository
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        void AddAll(List<T> entity);
        void Delete(T entity);
        void DeleteAll(Expression<Func<T, bool>> filter = null);
        void Edit(T entity);
        void EditAll(List<T> entity);
        T FirstOrDefault(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes);
        T SingleOrDefault(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
    }
}
