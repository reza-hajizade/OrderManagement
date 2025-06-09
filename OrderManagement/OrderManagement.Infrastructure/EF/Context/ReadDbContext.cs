using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;


namespace OrderManagement.Infrastructure.EF.Context
{
    public class ReadDbContext : DbContext
    {
        public DbSet<OrderReadModel> orderReadModels { get; set; }
        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Order");
            modelBuilder.Entity<OrderReadModel>().ToTable("Orders")
                .Property(o => o.Status)
        .HasConversion<string>(); ;

        }
    }
}
