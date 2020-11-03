namespace MyInventory.API.Models
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
