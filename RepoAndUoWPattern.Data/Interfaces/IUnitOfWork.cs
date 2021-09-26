using System;
using System.Threading.Tasks;

namespace RepoAndUoWPattern.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : class;

        int Commit();
        Task<int> CommitAsync();
    }

    public interface IUnitOfWork<out TContext> : IUnitOfWork
    {
        TContext Context { get; }
    }
}
