using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SmartClinic.Domain.Interfaces.Repositories.Base;

namespace SmartClinic.Data.Repositories.Base
{
    public abstract class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
    {
        #region Constructor

        protected RepositoryBase(DbContext context)
        {
            Context = context;
        }

        #endregion

        #region Properties

        protected DbContext Context { get; set; }

        #endregion

        #region Methods

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }

        public T Get(Guid id)
        {
            var entity = Context.Set<T>().Find(id);
            if(entity == null)
                throw new Exception(string.Format("Não foi encontrado nenhuma entidade com o ID {0}", id));

            return entity;
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            var entities = Context.Set<T>().Where(predicate).ToList();
            return entities;
        }

        public IEnumerable<T> GetAll()
        {
            var entities = Context.Set<T>().AsNoTracking().ToList();
            return entities;
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public void SaveOrAdd(T entity)
        {
            var obj = Get((Guid)entity.GetType().GetProperty("Id").GetValue(entity));

            if (obj == null || Guid.Empty == (Guid)obj.GetType().GetProperty("Id").GetValue(entity))
                Add(entity);
            else
                Update(entity);
        }

        #endregion
    }
}