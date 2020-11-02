namespace MyInventory.API.Services
{
    public interface IOrderService
    {
        public OrderDto CreateOrder(int shoppingCartId);
        public OrderDto ChangeOrderStatus(int shoppingCartId, );
    }

    public class OrderService : IOrderService
    {
       
    }
}
