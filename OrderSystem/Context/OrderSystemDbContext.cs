using Microsoft.EntityFrameworkCore;
using OrderSystem.Models;
using OrderSystem.Models.Domain;

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