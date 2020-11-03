using MyInventory.API.Enum;

namespace MyInventory.API.Services
{
    public interface IOrderService
    {
        public OrderDto CreateOrder(int shoppingCartId, double discount = 0);
        public OrderDto ChangeOrderStatus(int shoppingCartId, OrderStatus status);
    }

    public class OrderService : IOrderService
    {
       
    }
}
