using ECommerceApi.Application.Repositories;
using ECommerceApi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new(){Id=Guid.NewGuid(), Name="telefon", Price=100, CreatedDate=DateTime.UtcNow, Stock=10},
                new(){Id=Guid.NewGuid(), Name="tablet", Price=200, CreatedDate=DateTime.UtcNow, Stock=10},
                new(){Id=Guid.NewGuid(), Name="pc", Price=300, CreatedDate=DateTime.UtcNow, Stock=10},
            });
           var count = await _productWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
