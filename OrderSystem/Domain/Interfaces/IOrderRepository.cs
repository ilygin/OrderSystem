using OrderSystem.Domain.Models;

namespace OrderSystem.Domain.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        Order? UpdateOrder(Guid id, Order order);
        int UpdateOrdersRange(List<Order> orders);
        int DeleteOrder(Order order);
        int DeleteOrderRange(List<Order> orders);
        Order? GetOrderById(Guid orderId);
        IEnumerable<Order> GetAllOrders();
    }
}
