using OrderSystem.Domain.DTO;
using OrderSystem.Domain.Models;

namespace OrderSystem.Domain.Interfaces
{
    public interface IOrderService
    {
        public Order GetOrder(Guid id);
        public IEnumerable<Order> GetAllOrders();
        public Order CreateOrder(OrderRequestDto data);
        public Order? UpdateOrder(Guid id, OrderRequestDto data);
        public bool DeleteOrder(OrderRequestDto data);
    }
}