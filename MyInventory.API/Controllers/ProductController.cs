using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyInventory.API.Models.Dtos;
using MyInventory.API.Services;

namespace MyInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public ProductDto GetProduct(int id)
        {
            return _productService.GetProduct(id);
        }

        [HttpGet]
        public IEnumerable<ProductDto> GetProducts()
        {
            return _productService.GetProducts();
        }
    }
}
