using System.Collections.Generic;
using System.Linq;

namespace MyInventory.API.Models.Dtos
{
    public class ShoppingCartDto
    {
        public int Id { get; set; }
        public ClientDto Client { get; set; }
        public List<ProductDto> Products { get; set; }

        public static ShoppingCartDto ToDto(ShoppingCart shoppingCart)
        {
            return new ShoppingCartDto
            {
                Id = shoppingCart.Id, 
                Client = ClientDto.ToDto(shoppingCart.Client), 
                Products = shoppingCart.Products.Select(ProductDto.ToDto).ToList()
            };
        }
    }
}
