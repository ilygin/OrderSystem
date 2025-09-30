using OrderSystem.Domain.DTO;
using OrderSystem.Domain.Interfaces;
using OrderSystem.Domain.Models;

namespace OrderSystem.Application
{
    public class OrderService(IOrderRepository orderRepository) : IOrderService
    {
        private readonly IOrderRepository _orderRepository = orderRepository;

        public Order? GetOrder(Guid id)
        {
            if (id == Guid.Empty) return null;
            return _orderRepository.GetOrderById(id);
        }
        public IEnumerable<Order> GetAllOrders()
        { 
            return _orderRepository.GetAllOrders(); 
        }
        public Order CreateOrder(OrderRequestDto data)
        {
            Order order = new Order()
            {
                CreatedOn = DateTime.Now,
                CustomerName = data.CustomerName,
                TotalAmount = data.Amount * data.Count
            };
            if (order.TotalAmount < 0)
            {
                throw new Exception("Amount must be greater or equal 0;");
            }

            if (order.CustomerName == null || order.CustomerName == string.Empty)
            {
                throw new Exception("CustomerName must be fiiled in.");
            }
            _orderRepository.CreateOrder(order);
            return new Order();
        }
        public Order? UpdateOrder(Guid id, OrderRequestDto data)
        {
            if(id == Guid.Empty) return null;
            Order order = new Order()
            {
                Id = id,
                CreatedOn = DateTime.Now,
                CustomerName = data.CustomerName,
                TotalAmount = data.Amount * data.Count
            };

            if (order.TotalAmount < 0)
            {
                throw new Exception("Amount must be greater or equal 0;");
            }

            if (order.CustomerName == null || order.CustomerName == string.Empty)
            {
                throw new Exception("CustomerName must be fiiled in.");
            }
            return _orderRepository.UpdateOrder(order);
        }

        public bool DeleteOrder(OrderRequestDto data)
        {
            if (data == null) return false;
            Order? order = _orderRepository.GetOrderById(data.Id);
            if (order == null) return false;
            int count = _orderRepository.DeleteOrder(order);
            return count == 1;
        }
    }
}
