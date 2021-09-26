using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepoAndUoWPattern.Data.Interfaces;

namespace RepoAndUoWPattern.Repository.Data
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>
    where TContext : DbContext, IDisposable
    {
        private Dictionary<(Type type, string name), object> _repositories;
        public TContext Context { get; }

        public UnitOfWork(TContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IGenericRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : class
        {
            return (IGenericRepositoryAsync<TEntity>)GetOrAddRepository(typeof(TEntity),
                new GenericRepositoryAsync<TEntity>(Context));
        }

        public int Commit()
        {

            return Context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

        private object GetOrAddRepository(Type type, object repo)
        {
            _repositories = new Dictionary<(Type type, string Name), object>();

            if (_repositories.TryGetValue((type, repo.GetType().FullName), out var repository)) return repository;
            _repositories.Add((type, repo.GetType().FullName), repo);
            return repo;
        }
    }
}
