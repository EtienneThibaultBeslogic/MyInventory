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
        public OrderDto ChangeOrderStatus(int shoppingCartId, OrderStatus status)
        {
            throw new System.NotImplementedException();
        }

        public OrderDto CreateOrder(int shoppingCartId)
        {
            throw new System.NotImplementedException();
        }
    }
}
