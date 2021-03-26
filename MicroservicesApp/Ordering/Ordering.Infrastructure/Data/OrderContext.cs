using Microsoft.EntityFrameworkCore;
using Ordering.Core.Entities;

namespace Ordering.Infrastructure.Data
{
    /*
     * Required packages :
     * 1. Microsoft.EntityFrameworkCore
     * 2. Microsoft.EntityFrameworkCore.Design
     * 3. Microsoft.EntityFrameworkCore.InMemory
     * 4. Microsoft.EntityFrameworkCore.SqlServer
     * 5. Microsoft.EntityFrameworkCore.Tools
     */
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
            
        }

        public DbSet<Order> Orders { get; set; }
    }
}
