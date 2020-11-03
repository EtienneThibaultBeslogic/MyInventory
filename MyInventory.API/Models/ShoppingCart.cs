using MyInventory.API.Models.Dtos;
using System.Collections.Generic;

namespace MyInventory.API.Models
{
    public class ShoppingCart: BaseEntity
    {
        public Client Client { get; set; }
        public virtual Order? Order { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public ShoppingCartDto ToDto()
        {
            return new ShoppingCartDto { Id = Id, Client = Client, Products = Products };
        }
    }
}
