using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Infrastructure.EF.Context
{
    public class OrderManagementDbContext(DbContextOptions<OrderManagementDbContext> dbContextOptions)
      : DbContext(dbContextOptions)
    {
        public DbSet<Order> Orders { get; set; }
    }
}
