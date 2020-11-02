using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyInventory.API.Models;

namespace MyInventory.API.Services.Settings
{
    public interface IRepository<T> : IQueryable<T> where T : BaseEntity, new()
    {
        T Create(T entity);
        void Create(IEnumerable<T> entities);
        T Update(T entity);
        void Update(IEnumerable<T> entity);
        void Delete(T entity);
        void DeleteById(int id);
        void Delete(IEnumerable<T> entities);
    }

    public class EntityFrameworkRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly DbSet<T> _set;
        private readonly ApplicationDbContext _applicationDbContext;

        public EntityFrameworkRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
            _set = _applicationDbContext.Set<T>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _set.AsQueryable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Type ElementType { get { return _set.AsQueryable().ElementType; } }

        public Expression Expression { get { return _set.AsQueryable().Expression; } }

        public IQueryProvider Provider { get { return _set.AsQueryable().Provider; } }

        public T Create(T entity)
        {
            var result = _set.Add(entity);
            _applicationDbContext.SaveChanges();
            return result.Entity;
        }

        public void Create(IEnumerable<T> entities)
        {
            _set.AddRange(entities);
            _applicationDbContext.SaveChanges();
        }

        public T Update(T entity)
        {
            var trackedEntity = entity.Id == 0 ? entity : Get(entity.Id);

            var entry = _applicationDbContext.Entry(trackedEntity);

            if (entry.State != EntityState.Added)
            {
                entry.CurrentValues.SetValues(entity);
            }

            _applicationDbContext.SaveChanges();

            return entity;
        }

        public virtual T Get(params object[] ids) =>
                _applicationDbContext.Set<T>().Find(ids);

        public void Update(IEnumerable<T> entities)
        {
            _set.UpdateRange(entities);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
            _applicationDbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var entity = new T() { Id = id };
            _set.Attach(entity);
            _set.Remove(entity);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(IEnumerable<T> entities)
        {
            _set.RemoveRange(entities);
            _applicationDbContext.SaveChanges();
        }
    }
}
