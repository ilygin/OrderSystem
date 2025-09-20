using Microsoft.EntityFrameworkCore;
using OrderSystem.Domain.Entities;

namespace OrderSystem.Infrastructure.Data
{
    public class OrderSystemDbContext : DbContext
    {
        public OrderSystemDbContext(DbContextOptions<OrderSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}