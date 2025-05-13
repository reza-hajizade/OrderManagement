using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Infrastructure.EF.Context;

namespace OrderManagement.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderManagementDbContext _context;

        public UnitOfWork(OrderManagementDbContext context)
        {
            _context = context;
        }
        public async Task<int> SaveChangeAsync()
        {
           return await _context.SaveChangesAsync();
        }
    }
}
