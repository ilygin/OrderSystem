using Microsoft.EntityFrameworkCore;
using OrderSystem.Context;
using OrderSystem.Domain.Models;
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
            }

            // Act
            using (var context = new OrderSystemDbContext(options))
            {
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
                context.Orders.Add(new Order
                {
                    Id = orderId,
                    CustomerName = "Test Customer",
                    TotalAmount = 100.50m,
                    CreatedOn = DateTime.UtcNow,
                    ModifiedOn = DateTime.UtcNow
                });
            }

            //Act
            using (var context = new OrderSystemDbContext(options))
            {
                var repository = new OrderRepository(context);
                Order order = new Order { Id = orderId };
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
            }

            using (var context = new OrderSystemDbContext(options))
            {
                var repository = new OrderRepository(context);
                order.CustomerName = "Updated Customer";
                int counter = repository.UpdateOrder(order);
                Assert.Equal(1, counter);
            }

            using (var context = new OrderSystemDbContext(options))
            {
                var repository = new OrderRepository(context);
                var updatedOrder = repository.GetOrderById(order.Id);
            }
            Assert.NotNull(order);
            Assert.Equal("Updated Customer", order.CustomerName);
        }
    }
}