using Microsoft.EntityFrameworkCore;
using OrderSystem.Domain.Models;

namespace OrderSystem.Context
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