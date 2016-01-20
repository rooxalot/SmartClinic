using System;
using System.Collections.Generic;

namespace SmartClinic.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        T Get(Guid id);
        IEnumerable<T> Find(Func<T, bool> predicate);
        IEnumerable<T> GetAll();


        void Update(T entity);


        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        void SaveOrAdd(T entity);
    }
}