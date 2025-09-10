using OrderSystem.Domain.Models;

namespace OrderSystem.Domain.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        int UpdateOrder(Order order);
        int DeleteOrder(Guid orderId);
        Order? GetOrderById(Guid orderId);
        IEnumerable<Order> GetAllOrders();
    }
}
