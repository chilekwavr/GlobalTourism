using ApplicationCore.Interfaces;
using ApplicationCore.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbset;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public IEnumerable<T> FindWithSpecificationPattern(ISpecification<T> specification = null)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, bool noTracking = true)
        {
            IQueryable<T> query = _dbset.Where(predicate).AsQueryable();
            if (noTracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual T Add(T entity)
        {
            return _dbset.Add(entity).Entity;
        }

        public virtual async Task AddAsync(T entity)
        {
            await _dbset.AddAsync(entity);
        }
        public virtual T Delete(T entity)
        {
            return _dbset.Remove(entity).Entity;
        }
        public virtual T Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            //to prevent Edit from clearing CreatedDate
            //_context.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
            return entity;
        }

        public virtual bool Save()
        {
            return (_context.SaveChanges() > 0);
        }

        public virtual async Task<bool> SaveAsync()
        {
            var noRecordsChanged = await _context.SaveChangesAsync();
            return noRecordsChanged >= 0;
        }

        public virtual void AddTracking(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public virtual void RemoveTracking(T entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }
    }
}