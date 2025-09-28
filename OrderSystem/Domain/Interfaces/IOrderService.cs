using OrderSystem.Domain.DTO;
using OrderSystem.Domain.Models;

namespace OrderSystem.Domain.Interfaces
{
    public interface IOrderService
    {
        public Order GetOrder(OrderRequestDto data);
        public List<Order> GetAllOrders();
        public Order CreateOrder(OrderRequestDto data);
        public Order UpdateOrder(OrderRequestDto data);
        public int DeleteOrder(OrderRequestDto data);
    }
}
