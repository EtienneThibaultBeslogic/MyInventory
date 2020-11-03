using MyInventory.API.Enum;
using MyInventory.API.Models.Dtos;

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

        public OrderDto CreateOrder(int shoppingCartId, double discount = 0)
        {
            throw new System.NotImplementedException();
        }
    }
}
