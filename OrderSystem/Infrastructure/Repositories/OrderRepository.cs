using OrderSystem.Domain.Constants;
using OrderSystem.Domain.Interfaces;

using OrderSystem.Domain.Models;
using OrderSystem.Infrastructure.Context;

namespace OrderSystem.Infrastructure.Repositories
{
    public class OrderRepository(OrderSystemDbContext context) : IOrderRepository
    {
        private readonly OrderSystemDbContext _context = context;

        public void CreateOrder(Order order)
        {
            order.CreatedOn = DateTime.UtcNow;
            order.ModifiedOn = DateTime.UtcNow;
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
        public int CreateOrderBatch(List<Order> orders)
        {
            if (orders == null || orders.Count == 0) return 0;
            return orders.Chunk(PaginationOptions.BatchSize).Sum(batch => CreateOrderBatchQuery(batch.ToList()));
        }
        private int CreateOrderBatchQuery(List<Order> orders)
        {
            orders.ForEach(order =>
            {
                order.CreatedOn = DateTime.UtcNow;
                order.ModifiedOn = DateTime.UtcNow;
            });
            _context.Orders.AddRange(orders);
            return _context.SaveChanges();
        }

        public int UpdateOrder(Order order)
        {
            if (order == null) return 0;
            order.ModifiedOn = DateTime.UtcNow;
            _context.Orders.Update(order);
            return 1;
        }
        public int UpdateOrdersRange(List<Order> orders)
        {
            if (orders == null || orders.Count == 0) return 0;
            orders.ForEach(order => order.ModifiedOn = DateTime.UtcNow);
            _context.Orders.UpdateRange(orders);
            return orders.Count;
        }

        public int DeleteOrder(Order order)
        {
            if (order == null) return 0;
            var result = _context.Orders.Remove(order);
            return result.Entity.Id != Guid.Empty ? 1 : 0;
        }
        public int DeleteOrderRange(List<Order> orders)
        {
            if (orders == null || orders.Count == 0) return 0;
            _context.Orders.RemoveRange(orders);
            return orders.Count;
        }
        public Order? GetOrderById(Guid orderId)
        {
            if(orderId == Guid.Empty) return null;
            return _context.Orders.Find(orderId);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            int totalCount = _context.Orders.Count();
            int totalPages = (totalCount + PaginationOptions.PageSize - 1) / PaginationOptions.PageSize;
            
            for (int pageNumber = 1; pageNumber <= totalPages; pageNumber++)
            {
                foreach (var order in GetOrdersByPage(pageNumber, PaginationOptions.PageSize))
                {
                    yield return order;
                }
            }
        }
        private IEnumerable<Order> GetOrdersByPage(int pageNumber, int pageSize)
        {
            return _context.Orders.OrderBy(o => o.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}
