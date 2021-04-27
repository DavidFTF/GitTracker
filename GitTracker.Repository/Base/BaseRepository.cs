using GitTracker.Domain.Contracts.Repository;
using GitTracker.Repository.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace GitTracker.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IAppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(IAppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddAll(IList<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public T Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void UpdateAll(IList<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public virtual void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual async Task RemoveAll()
        {
            _context.Set<T>().RemoveRange(_context.Set<T>());
            await _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        protected virtual IQueryable<T> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        protected virtual IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return AsQueryable().Where(predicate);
        }
    }
}