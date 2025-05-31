using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
