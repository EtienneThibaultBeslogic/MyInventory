using MyInventory.API.Models.Dtos;

namespace MyInventory.API.Services
{
    public interface IShoppingCartService
    {
        public ShoppingCartDto CreateShoppingCart(ClientDto clientDto);
        public ShoppingCartDto AddProductToShoppingCart(int shoppingCartId, ProductDto productDto);
    }

    public class ShoppingCartService : IShoppingCartService
    {
       
    }
}
