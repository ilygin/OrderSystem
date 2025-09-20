using OrderSystem.Context;
using OrderSystem.Domain.Interfaces;
using OrderSystem.Domain.Models;

namespace OrderSystem.Infrastructure.Repositories
{
    public class OrderRepository(OrderSystemDbContext context) : IOrderRepository
    {
        private const int BATCH_SIZE = 2000;
        private readonly OrderSystemDbContext _context = context;
        //TODO: Implement Controllers, Services. Add mappers. Split Domain and Dtos. 
        public void CreateOrder(Order order)
        {
            order.CreatedOn = DateTime.UtcNow;
            order.ModifiedOn = DateTime.UtcNow;
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
        public int CreateOrderBatch(List<Order> orders)
        {
            if (orders == null || !orders.Any()) return 0;
            return orders.Chunk(BATCH_SIZE).Sum(batch => CreateOrderBatchQuery(batch.ToList()));
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
            order.ModifiedOn = DateTime.UtcNow;
            _context.Orders.Update(order);
            return 1;
        }
        public int UpdateOrders(List<Order> orders)
        {
            orders.ForEach(order => order.ModifiedOn = DateTime.UtcNow);
            _context.Orders.UpdateRange(orders);
            return orders.Count;
        }

        public int DeleteOrder(Guid orderId)
        {
            throw new NotImplementedException();
        }
        public Order? GetOrderById(Guid orderId)
        {
            return _context.Orders.Find(orderId);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }
    }
}
