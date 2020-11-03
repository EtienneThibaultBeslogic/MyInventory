using System.Collections.Generic;

namespace MyInventory.API.Models
{
    public class ShoppingCart: BaseEntity
    {
        public Client Client { get; set; }
        public List<Product> Products { get; set; }
    }
}
