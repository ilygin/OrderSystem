using Microsoft.EntityFrameworkCore;
using OrderSystem.Domain.Models;
using OrderSystem.Infrastructure.Context;
using OrderSystem.Infrastructure.Repositories;

namespace OrderSystem.Tests
{
    public class OrderRepositoryTests
    {
        private static DbContextOptions<OrderSystemDbContext> GetDbContextOptions()
        {
            return new DbContextOptionsBuilder<OrderSystemDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task GetById_ShouldReturnOrder_WhenOrderExists()
        {
            // Arrange
            var options = GetDbContextOptions();
            var orderId = Guid.NewGuid();

            using (var context = new OrderSystemDbContext(options))
            {
                context.Orders.Add(new Order
                {
                    Id = orderId,
                    CustomerName = "Test Customer",
                    TotalAmount = 100.50m,
                    CreatedOn = DateTime.UtcNow,
                    ModifiedOn = DateTime.UtcNow
                });
                await context.SaveChangesAsync();
                var repository = new OrderRepository(context);
                var result = repository.GetOrderById(orderId);

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Test Customer", result.CustomerName);
                Assert.Equal(100.50m, result.TotalAmount);
            }
        }

        [Fact]
        public void RemoveById_ShouldRemoveOrder_WhenOrderExists()
        {
            //Arrange
            var options = GetDbContextOptions();
            var orderId = Guid.NewGuid();

            using (var context = new OrderSystemDbContext(options))
            {
                var repository = new OrderRepository(context);
                var order = new Order
                {
                    Id = orderId,
                    CustomerName = "Test Customer",
                    TotalAmount = 100.50m,
                    CreatedOn = DateTime.UtcNow,
                    ModifiedOn = DateTime.UtcNow
                };
                repository.CreateOrder(order);
                var result = repository.DeleteOrder(order);
                Assert.Equal(1, result);
            }
        }

        [Fact]
        public void UpdateOrder_ShouldChangeName_WhenOrderExists()
        {
            //Arrange
            var options = GetDbContextOptions();
            Order order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerName = "Test Customer",
                TotalAmount = 100.50m,
                CreatedOn = DateTime.UtcNow,
                ModifiedOn = DateTime.UtcNow
            };

            using (var context = new OrderSystemDbContext(options))
            {
                var repository = new OrderRepository(context);
                repository.CreateOrder(order);

                order.CustomerName = "Updated Customer";
                int counter = repository.UpdateOrder(order);
                Assert.Equal(1, counter);

                var updatedOrder = repository.GetOrderById(order.Id);
                Assert.NotNull(updatedOrder);
                Assert.Equal("Updated Customer", updatedOrder.CustomerName);
            }
        }
    }
}