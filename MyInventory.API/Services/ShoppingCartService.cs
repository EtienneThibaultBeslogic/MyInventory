using MyInventory.API.Models;
using MyInventory.API.Models.Dtos;
using MyInventory.API.Services.Settings;
using System.Linq;

namespace MyInventory.API.Services
{
    public interface IShoppingCartService
    {
        public ShoppingCartDto CreateShoppingCart(ClientDto clientDto);
        public ShoppingCartDto AddProductToShoppingCart(int shoppingCartId, int productId);
    }

    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _cartRepo;
        private readonly IRepository<Product> _productRepo;
        public ShoppingCartService(
            IRepository<ShoppingCart> cartRepo,
            IRepository<Product> productRepo
            )
        {
            _cartRepo = cartRepo;
            _productRepo = productRepo;
        }
        public ShoppingCartDto AddProductToShoppingCart(int shoppingCartId, int productId)
        {
            var cart = _cartRepo.SingleOrDefault(x => x.Id == shoppingCartId);

            var product = _productRepo.SingleOrDefault(x => x.Id == productId);

            cart.Products.Add(product);

            var cartUpdated = _cartRepo.Update(cart);

            return cartUpdated.ToDto();
        }

        public ShoppingCartDto CreateShoppingCart(ClientDto clientDto)
        {
            return _cartRepo.Create(new ShoppingCart { Client = clientDto.FromDto() }).ToDto();
        }
    }
}
