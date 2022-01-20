using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IGenericRepository<T, TType> where T : class
    {
        //Task<IEnumerable<T>> Get();
        //Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate);
        //Task<T> GetById(int id);
        //Task Add(T entity);
        //void Update(T entity);
        ////void Delete(T entity);
        //int SaveChanges();
        //Task<int> SaveChangesAsync();

        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(TType id);
        Task<IEnumerable<T>> GetByExpression(Expression<Func<T, bool>> predicate);
        T SingleOrDefault(Expression<Func<T, bool>> predicate);
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        void AddRange(IEnumerable<T> entities);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Remove(T entity);
        Task RemoveById(TType id);
        void RemoveRange(IEnumerable<T> entities);
        IEnumerable<T> Include(params Expression<Func<T, object>>[] includes);
        Task<bool> CanSafeToRemove(T entity);
        T Update(T entity);

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }

}
