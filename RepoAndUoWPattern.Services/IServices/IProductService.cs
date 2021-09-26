using System.Collections.Generic;
using System.Threading.Tasks;
using RepoAndUoWPattern.Data.Entities;

namespace RepoAndUoWPattern.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ProductList();
        Task<Product> GetProductById(int id);
    }
}
