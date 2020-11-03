using System.Collections.Generic;
using System.Linq;
using MyInventory.API.Models;
using MyInventory.API.Models.Dtos;
using MyInventory.API.Services.Settings;

namespace MyInventory.API.Services
{
    public interface IProductService
    {
        public ProductDto GetProduct(int id);
        public IEnumerable<ProductDto> GetProducts();
    }

    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productsRepo;

        public ProductService(IRepository<Product> productsRepo)
        {
            _productsRepo = productsRepo;
        }

        public ProductDto GetProduct(int id)
        {
            var client = _productsRepo.SingleOrDefault(c => c.Id == id);
            return client == null ? null : ProductDto.ToDto(client);
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            return _productsRepo.Select(client => ProductDto.ToDto(client));
        }
    }
}
