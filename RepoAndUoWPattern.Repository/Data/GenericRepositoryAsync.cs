using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RepoAndUoWPattern.Data.Interfaces;

namespace RepoAndUoWPattern.Repository.Data
{
    public sealed class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly DbSet<T> _dbSet;

        public GenericRepositoryAsync(DbContext context)
        {
            _dbSet = context.Set<T>();

        }
        
        public async Task<IEnumerable<T>> GetListAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<int> Count()
        {
            return await _dbSet.CountAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public ValueTask<EntityEntry<T>> InsertAsync(T entity)
        {
            return _dbSet.AddAsync(entity);
        }

        public Task InsertAsync(params T[] entities)
        {
            return  _dbSet.AddRangeAsync(entities);
        }

        public Task InsertAsync(IEnumerable<T> entities)
        {
            return  _dbSet.AddRangeAsync(entities);
        }


       

    }
}
