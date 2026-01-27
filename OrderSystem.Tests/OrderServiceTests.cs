using Microsoft.EntityFrameworkCore;
using OrderSystem.Application;
using OrderSystem.Domain.DTO;
using OrderSystem.Domain.Models;
using OrderSystem.Infrastructure.Context;
using OrderSystem.Infrastructure.Repositories;
using System;

namespace OrderSystem.Tests
{
    public class OrderServiceTests
    {
        private static DbContextOptions<OrderSystemDbContext> GetDbContextOptions()
        {
            return new DbContextOptionsBuilder<OrderSystemDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public void CreateOrder_ShouldCreateOrder()
        {
            using var context = new OrderSystemDbContext(GetDbContextOptions());
            var repository = new OrderRepository(context);
            var orderService = new OrderService(repository);
            // Arrange
            var orderId = Guid.NewGuid();
            OrderRequestDto testRecord = new()
            {
                Id = orderId,
                CustomerName = "Test Customer",
                Count = 100,
                Amount = 100.50m
            };

            var createdOrder = orderService.CreateOrder(testRecord);

            // Assert
            var result = repository.GetOrderById(orderId);
            Assert.NotNull(result);
            Assert.Equal("Test Customer", result.CustomerName);
            Assert.Equal(10050.00m, result.TotalAmount);
        }

        [Fact]
        public void GetOrderById_ShouldReturnOrder()
        {
            using var context = new OrderSystemDbContext(GetDbContextOptions());
            var repository = new OrderRepository(context);
            var orderService = new OrderService(repository);
            // Arrange
            var orderId = Guid.NewGuid();
            OrderRequestDto testRecord = new()
            {
                Id = orderId,
                CustomerName = "Test Customer",
                Count = 100,
                Amount = 100.50m
            };
            orderService.CreateOrder(testRecord);
            Order? result = repository.GetOrderById(orderId);
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Customer", result.CustomerName);
            Assert.Equal(10050.00m, result.TotalAmount);
        }

        [Fact]
        public void GetOrderById_ShouldReturnNull()
        {
            using var context = new OrderSystemDbContext(GetDbContextOptions());
            var repository = new OrderRepository(context);
            var orderService = new OrderService(repository);
            // Arrange
            OrderRequestDto testRecord = new()
            {
                Id = Guid.NewGuid(),
                CustomerName = "Test Customer",
                Count = 100,
                Amount = 100.50m
            };
            var createdOrder = orderService.CreateOrder(testRecord);
            Order? result = repository.GetOrderById(Guid.NewGuid());
            // Assert
            Assert.Null(result);
        }
    }
}
