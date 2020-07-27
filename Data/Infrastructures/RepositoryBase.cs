using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Infrastructures
{
    public abstract class RepositoryBase<T> where T : class
    {
        #region Properties
        private OnlineStoreDbContext dbContext;
        private readonly DbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected OnlineStoreDbContext DbContext
        {
            get { return dbContext ?? (dbContext = DbFactory.Init()); }
        }
        #endregion
        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }
        #region Implementation
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public virtual void Update(T entity)
        {

            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }
        public virtual T GetByDynamicId(dynamic id)
        {
            return dbSet.Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return dbSet;
        }
        public virtual List<T> GetPaged(int page, int pageSize)
        {
            return dbSet.Skip(page * pageSize).Take(pageSize).ToList();
        }
        #endregion
    }
}
