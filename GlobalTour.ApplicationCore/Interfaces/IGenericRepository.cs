using ApplicationCore.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync();

        IEnumerable<T> FindWithSpecificationPattern(ISpecification<T> specification = null);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, bool noTracking = true);
        T Add(T entity);

        Task AddAsync(T entity);

        T Delete(T entity);

        T Edit(T entity);
        bool Save();

        void AddTracking(T entity);
        void RemoveTracking(T entity);

        Task<bool> SaveAsync();

    }
}