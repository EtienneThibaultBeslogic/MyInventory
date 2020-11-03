using System.Collections.Generic;
using MyInventory.API.Enum;

namespace MyInventory.API.Models
{
    public class Order: BaseEntity
    {
        public Client Client { get; set; }
        public int ShoppingCartId { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
        public double Discount { get; set; }
        public double Price { get; set; }
        public OrderStatus Status { get; set; }
    }
}
