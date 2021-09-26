using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepoAndUoWPattern.Services.IServices;

namespace RepoAndUoWPattern.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok( await _service.ProductList());
        }
    }
}
