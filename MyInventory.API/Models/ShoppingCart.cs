using System.Collections.Generic;

namespace MyInventory.API.Models
{
    public class ShoppingCart: BaseEntity
    {
        public Client Client { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
