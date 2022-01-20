using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GenericRepository<T,TType> : IGenericRepository<T,TType> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        protected DbSet<T> dbSet;
        protected DbContext dbContext;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            if (_unitOfWork.Context != null)
            {
                dbContext = _unitOfWork.Context;
                dbSet = dbContext.Set<T>();
            }
        }

        //public async Task<IEnumerable<T>> Get()
        //{
        //    return await dbSet.ToListAsync();
        //}

        //public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate)
        //{
        //    return await dbSet.Where(predicate).ToListAsync();
        //}

        //public async Task<T> GetById(int id)
        //{
        //    return await dbSet.FindAsync(id);
        //}

        //public async Task Add(T entity)
        //{
        //    await dbSet.AddAsync(entity);
        //}

        //public void Update(T entity)
        //{
        //    dbSet.Update(entity);
        //}

        ////public void Delete(T entity)
        ////{
        ////    dbSet.Remove(entity);
        ////}

        //public int SaveChanges()
        //{
        //    return _unitOfWork.Context.SaveChanges();
        //}

        //public async Task<int> SaveChangesAsync()
        //{
        //    return await _unitOfWork.Context.SaveChangesAsync();
        //}


        public async Task<T> GetById(TType id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetByExpression(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return dbSet.SingleOrDefault(predicate);
        }

        public async Task<T> AddAsync(T entity)
        {
            var result = await dbSet.AddAsync(entity);
            return result.Entity;
        }

        public T Update(T entity)
        {
            return dbSet.Update(entity).Entity;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public async Task RemoveById(TType id)
        {
             var entity = await GetById(id);
            Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public IEnumerable<T> Include(params Expression<Func<T, object>>[] includeExpressions)
        {
            IQueryable<T> query = null;
            foreach (var includeExpression in includeExpressions)
            {
                query = dbSet.Include(includeExpression);
            }

            return query ?? dbSet;
        }

        public Task<bool> CanSafeToRemove(T entity)
        {
            throw new NotImplementedException();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }
        public int SaveChanges()
        {
            return _unitOfWork.Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.Context.SaveChangesAsync();
        }
    }

}
