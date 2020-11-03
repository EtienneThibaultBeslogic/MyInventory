using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyInventory.API.Models.Dtos;
using MyInventory.API.Services;
using MyInventory.API.Services.Settings;

namespace MyInventory.API.Controllers
{
    public class ProductController : ApiControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            return Json(_productService.GetProduct(id));
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Json(_productService.GetProducts());
        }
    }
}
