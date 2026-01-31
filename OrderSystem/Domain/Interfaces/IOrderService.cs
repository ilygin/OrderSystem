using OrderSystem.Domain.DTO;
using OrderSystem.Domain.Models;
using OrderSystem.Domain.Common;

namespace OrderSystem.Domain.Interfaces
{
    public interface IOrderService
    {
        public Result<Order> GetOrder(Guid id);
        public Result<IEnumerable<Order>>  GetAllOrders();
        public Result<Order> CreateOrder(OrderRequestDto data);
        public Result<Order> UpdateOrder(Guid id, OrderRequestDto data);
        public Result<bool> DeleteOrder(OrderRequestDto data);
        public Result<bool>  DeleteOrder(Guid id);
    }
}