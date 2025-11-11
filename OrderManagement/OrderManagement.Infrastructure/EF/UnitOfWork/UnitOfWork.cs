using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Infrastructure.EF.Context;
using OrderManagement.Infrastructure.UnitOfWork;

namespace OrderManagement.Infrastructure.EF.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WriteDbContext _context;

        public UnitOfWork(WriteDbContext context)
        {
            _context = context;
        }
        public async Task<int> SaveChangeAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
