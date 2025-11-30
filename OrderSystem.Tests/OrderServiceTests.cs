using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OrderSystem.Application;
using OrderSystem.Domain.DTO;
using OrderSystem.Domain.Interfaces;
using OrderSystem.Domain.Models;
using OrderSystem.Infrastructure.Context;
using OrderSystem.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Tests
{
    public class OrderServiceTests
    {
        private readonly OrderSystemDbContext _context;
        private readonly IOrderService _orderService;
        private readonly IOrderRepository _repository;

        public OrderServiceTests()
        {
            var options = new DbContextOptionsBuilder<OrderSystemDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new OrderSystemDbContext(options);
            _repository = new OrderRepository(_context);
            _orderService = new OrderService(_repository);
        }

        [Fact]
        public void CreateOrderAsync_ShouldCreateOrder()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            OrderRequestDto testRecord = new()
            {
                Id = orderId,
                CustomerName = "Test Customer",
                Count = 100,
                Amount = 100.50m
            };

            var createdOrder = _orderService.CreateOrder(testRecord);

            // Assert
            var result = _repository.GetOrderById(orderId);
            Assert.NotNull(result);
            Assert.Equal("Test Customer", result.CustomerName);
            Assert.Equal(10050.00m, result.TotalAmount);
        }

        [Fact]
        public void GetOrderById_ShouldReturnOrder()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            OrderRequestDto testRecord = new()
            {
                Id = orderId,
                CustomerName = "Test Customer",
                Count = 100,
                Amount = 100.50m
            };
            var createdOrder = _orderService.CreateOrder(testRecord);
            Order? result = _repository.GetOrderById(orderId);
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Customer", result.CustomerName);
            Assert.Equal(10050.00m, result.TotalAmount);
        }

        [Fact]
        public void GetOrderById_ShouldReturnNull()
        {
            // Arrange
            OrderRequestDto testRecord = new()
            {
                Id = Guid.NewGuid(),
                CustomerName = "Test Customer",
                Count = 100,
                Amount = 100.50m
            };
            var createdOrder = _orderService.CreateOrder(testRecord);
            Order? result = _repository.GetOrderById(Guid.NewGuid());
            // Assert
            Assert.Null(result);
        }
    }
}
