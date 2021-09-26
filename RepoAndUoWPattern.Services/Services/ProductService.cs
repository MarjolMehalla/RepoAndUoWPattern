using System.Collections.Generic;
using System.Threading.Tasks;
using RepoAndUoWPattern.Data.Entities;
using RepoAndUoWPattern.Data.Interfaces;
using RepoAndUoWPattern.Services.IServices;

namespace RepoAndUoWPattern.Services.Services
{

   public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;

        public ProductService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<IEnumerable<Product>> ProductList()
        {
           
            return  await  _uow.GetRepositoryAsync<Product>().GetListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _uow.GetRepositoryAsync<Product>().GetByIdAsync(id);
        }
    }
}
