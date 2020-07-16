using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Infrastructures
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        IQueryable<T> GetAll();
        List<T> GetPaged(int page, int pageSize);
    }
}
