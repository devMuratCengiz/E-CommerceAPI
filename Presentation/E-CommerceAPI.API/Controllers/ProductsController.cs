using E_CommercaAPI.Application.Repositories.ProductRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _writeRepository;
        private readonly IProductReadRepository _readRepository;

        public ProductsController(IProductWriteRepository writeRepository, IProductReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        [HttpGet]
        public async void Get()
        {
            await _writeRepository.AddRangeAsync(
                new()
                {
                    new() {Id = Guid.NewGuid(),Name ="Product 1",Price = 100, CreatedDate = DateTime.UtcNow,Stock =10 },
                    new() {Id = Guid.NewGuid(),Name ="Product 2",Price = 200, CreatedDate = DateTime.UtcNow,Stock =20 },
                    new() {Id = Guid.NewGuid(),Name ="Product 3",Price = 300, CreatedDate = DateTime.UtcNow,Stock =30 }
                });
            await _writeRepository.SaveAsync();
        }
    }
}
