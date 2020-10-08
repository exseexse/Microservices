using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Core
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int Id);
        Task<T> AddAsync(T model);
        Task Remove(T model);
        Task<T> UpdateAsync(T model);      
        Task UpdateRangeAsync(List<T> models);
    }
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        protected readonly TContext _context;

        protected GenericRepository(TContext context)
        {
            _context = context;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            try
            {
                return _context.Set<TEntity>();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entities");
            }
        }

        public async Task<TEntity> AddAsync(TEntity model)
        {
            if (model == null)
            {
                throw new ArgumentNullException($"{nameof(model)} entity must not be null");
            }

            try
            {
                await _context.AddAsync(model);
                await _context.SaveChangesAsync();

                return model;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(model)} could not be saved");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity model)
        {
            if (model == null)
            {
                throw new ArgumentNullException($"{nameof(model)} entity must not be null");
            }

            try
            {
                _context.Update(model);
                await _context.SaveChangesAsync();

                return model;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(model)} could not be updated");
            }
        }

        public async Task UpdateRangeAsync(List<TEntity> models)
        {
            if (models == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateRangeAsync)} entities must not be null");
            }

            try
            {
                _context.UpdateRange(models);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(models)} could not be updated");
            }
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<TEntity>().FindAsync(id);
            }
            catch (Exception)
            {
                throw new Exception($"Couldn't retrieve entity");
            }
        }



        public async Task Remove(TEntity model)
        {
            if (model == null)
            {
                throw new ArgumentNullException($"{nameof(model)} entity must not be null");
            }

            try
            {
                _context.Set<TEntity>().Remove(model);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(model)} could not be removed");
            }

        }

    }
}
