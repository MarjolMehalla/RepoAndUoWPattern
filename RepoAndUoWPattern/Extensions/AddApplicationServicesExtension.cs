using Microsoft.Extensions.DependencyInjection;
using RepoAndUoWPattern.Data.Interfaces;
using RepoAndUoWPattern.Repository.Data;
using RepoAndUoWPattern.Services.IServices;
using RepoAndUoWPattern.Services.Services;

namespace RepoAndUoWPattern.API.Extensions
{
    public static class AddApplicationServicesExtension
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            return services;
        }
    }
}
