using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RepoAndUoWPattern.Data.Interfaces;
using RepoAndUoWPattern.Repository.Data;

namespace RepoAndUoWPattern.API.Extensions
{
    public static class UnitOfWorkServiceExtentions
    {

        public static IServiceCollection AddUnitOfWork<TContext>(this IServiceCollection services)
            where TContext : DbContext
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
            return services;
        }
    }
}
