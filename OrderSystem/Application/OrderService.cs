using OrderSystem.Domain.Common;
using OrderSystem.Domain.DTO;
using OrderSystem.Domain.Interfaces;
using OrderSystem.Domain.Models;

namespace OrderSystem.Application
{
    public class OrderService(IOrderRepository orderRepository) : IOrderService
    {
        private readonly IOrderRepository _orderRepository = orderRepository;

        public Result<Order> GetOrder(Guid id)
        {
            if (id == Guid.Empty) return Result<Order>.Failure(null, "OrderId is required.");
            return  Result<Order>.Success(_orderRepository.GetOrderById(id));
        }
        public Result<IEnumerable<Order>>  GetAllOrders()
        { 
            return Result<IEnumerable<Order>>.Success(_orderRepository.GetAllOrders()); 
        }
        public Result<Order> CreateOrder(OrderRequestDto data)
        {
            Order order = new Order()
            {
                Id = data.Id == Guid.Empty ? Guid.NewGuid() : data.Id,
                CreatedOn = DateTime.UtcNow,
                CustomerName = data.CustomerName,
                TotalAmount = data.Amount * data.Count,
                Status = data.Status,
            };
            if (order.TotalAmount < 0)
            {
                return Result<Order>.Failure(order, "Amount must be greater or equal 0;");
            }

            if (order.CustomerName == null || order.CustomerName == string.Empty)
            {
                return Result<Order>.Failure(order, "CustomerName must be filled in.");
            }
            _orderRepository.CreateOrder(order);
            return Result<Order>.Success(order);
        }
        public Result<Order> UpdateOrder(Guid id, OrderRequestDto data)
        {
            if(id == Guid.Empty) return Result<Order>.Failure(null, "OrderId is required.");
            Order? order = _orderRepository.GetOrderById(id);
            if (order == null) return Result<Order>.Failure(null, "Order not found");
            order.CustomerName = data.CustomerName;
            order.TotalAmount = data.Amount * data.Count;
            order.Status = data.Status;

            if (order.TotalAmount < 0)
            {
                return Result<Order>.Failure(null, "Amount must be greater or equal 0;");
            }

            if (order.CustomerName == null || order.CustomerName == string.Empty)
            {
                return Result<Order>.Failure(null, "CustomerName must be filled in.");
            }
            return Result<Order>.Success(_orderRepository.UpdateOrder(order));
        }

        public Result<bool> DeleteOrder(OrderRequestDto data)
        {
            if (data == null) return Result<bool>.Failure(false, "data is empty.");
            Order? order = _orderRepository.GetOrderById(data.Id);
            if (order == null) return Result<bool>.Failure(false, "order not found.");
            int count = _orderRepository.DeleteOrder(order);
            return Result<bool>.Success(count == 1);
        }

        public Result<bool> DeleteOrder(Guid id)
        {
           return DeleteOrder(new OrderRequestDto { Id = id });
        }
    }
}
