using Microsoft.EntityFrameworkCore;
using OrderSystem.Domain.Models;

namespace OrderSystem.Infrastructure.Context
{
    public class OrderSystemDbContext : DbContext
    {
        public OrderSystemDbContext(DbContextOptions<OrderSystemDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Order> Orders { get; set; }
    }
}