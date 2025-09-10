using OrderSystem.Domain.Interfaces;
using OrderSystem.Domain.Models;

namespace OrderSystem.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public void CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }
        public int UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
        public int DeleteOrder(Guid orderId)
        {
            throw new NotImplementedException();
        }
        public Order? GetOrderById(Guid orderId)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }
    }
}
