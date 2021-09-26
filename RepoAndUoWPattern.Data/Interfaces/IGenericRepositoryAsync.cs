using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace RepoAndUoWPattern.Data.Interfaces
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<IEnumerable<T>> GetListAsync();
        Task<int> Count();
        Task<T> GetByIdAsync(object id);


        ValueTask<EntityEntry<T>> InsertAsync(T entity);

        Task InsertAsync(params T[] entities);

        Task InsertAsync(IEnumerable<T> entities);

    }
}
