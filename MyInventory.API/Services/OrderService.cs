using MyInventory.API.Enum;
using MyInventory.API.Models.Dtos;

namespace MyInventory.API.Services
{
    public interface IOrderService
    {
        public OrderDto CreateOrder(int shoppingCartId);
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
