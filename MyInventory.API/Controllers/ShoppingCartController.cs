using Microsoft.AspNetCore.Mvc;
using MyInventory.API.Models.Dtos;
using MyInventory.API.Services;

namespace MyInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        public ShoppingCartDto GetShoppingCart(int shoppingCartId)
        {
            return _shoppingCartService.GetShoppingCart(shoppingCartId);
        }

        [HttpPut("create-shopping-cart")]
        public ShoppingCartDto CreateShoppingCart(int clientId)
        {
            return _shoppingCartService.CreateShoppingCart(clientId);
        }

        [HttpPost("add-product")]
        public ShoppingCartDto AddProductToShoppingCart(int shoppingCartId, int productId)
        {
            return _shoppingCartService.AddProductToShoppingCart(shoppingCartId, productId);
        }
    }
}
