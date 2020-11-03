using System.Collections.Generic;
using MyInventory.API.Models;
using MyInventory.API.Models.Dtos;
using MyInventory.API.Services.Settings;
using System.Linq;

namespace MyInventory.API.Services
{
    public interface IShoppingCartService
    {
        public ShoppingCartDto GetShoppingCart(int shoppingCartId);
        public ShoppingCartDto CreateShoppingCart(int clientId);
        public ShoppingCartDto AddProductToShoppingCart(int shoppingCartId, int productId);
    }

    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _cartRepo;
        private readonly IRepository<Product> _productRepo;
        private readonly IRepository<Client> _clientRepo;

        public ShoppingCartService(
            IRepository<ShoppingCart> cartRepo,
            IRepository<Product> productRepo,
            IRepository<Client> clientRepo)
        {
            _cartRepo = cartRepo;
            _productRepo = productRepo;
            _clientRepo = clientRepo;
        }

        public ShoppingCartDto GetShoppingCart(int shoppingCartId)
        {
            var cart = _cartRepo.SingleOrDefault(x => x.Id == shoppingCartId);

            return ShoppingCartDto.ToDto(cart);
        }

        public ShoppingCartDto CreateShoppingCart(int clientId)
        {
            var client = _clientRepo.SingleOrDefault(x => x.Id == clientId);

            var shoppingCart = _cartRepo.Create(
                new ShoppingCart
                {
                    Client = client,
                    Products = new List<Product>()
                });
            return ShoppingCartDto.ToDto(shoppingCart);
        }
    }
}
