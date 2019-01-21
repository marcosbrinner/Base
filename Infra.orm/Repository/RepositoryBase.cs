using Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.orm.Repository
{
    public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
    {
        internal Context context;
        internal DbSet<T> DbSet;

        public RepositoryBase(Context context)
        {
            this.context = context;
            this.DbSet = context.Set<T>();
            this.context.Configuration.LazyLoadingEnabled = true;
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void AddAll(List<T> entity)
        {
            DbSet.AddRange(entity);
        }

        public void Edit(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Modified;
        }

        public void EditAll(List<T> entity)
        {
            foreach (var item in entity)
            {
                context.Entry<T>(item).State = EntityState.Modified;
            }
        }

        public void Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            DbSet.Remove(entity);
        }

        public void DeleteAll(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = DbSet;
            var listDelete = query.Where(filter).ToList();

            foreach (var item in listDelete)
            {
                DbSet.Remove(item);
            }
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }



            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public virtual T FirstOrDefault(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
                query = query.Where(filter);

            return orderBy?.Invoke(query)?.FirstOrDefault() ?? query?.FirstOrDefault();
        }

        public virtual T SingleOrDefault(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
                query = query.Where(filter);

            return orderBy?.Invoke(query)?.SingleOrDefault();
        }

        public void Dispose()
        {
            DbSet = null;
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
