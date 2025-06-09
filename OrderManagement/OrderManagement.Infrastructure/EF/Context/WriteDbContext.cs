using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Infrastructure.EF.Context
{
    public class WriteDbContext:DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Order");
      

            modelBuilder.Entity<Order>()
                .ToTable("Orders")
                .Property(o => o.Status)
                .HasConversion<string>();
            
        }

    }
}
