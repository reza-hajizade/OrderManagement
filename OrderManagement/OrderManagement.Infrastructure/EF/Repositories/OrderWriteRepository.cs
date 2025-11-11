using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Repositories;
using OrderManagement.Infrastructure.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.EF.Repositories
{
    public class OrderWriteRepository : IOrderWriteRepository
    {
        private readonly WriteDbContext _writeDbContext;
        public OrderWriteRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
        }
        public async Task AddAsync(Order order, CancellationToken cancellationToken)
        {
           await _writeDbContext.Orders.AddAsync(order, cancellationToken);
        }

        public async Task<Order> GetOrderById(Guid id,CancellationToken cancellationToken)
        {
            var result= await _writeDbContext.Orders.FirstOrDefaultAsync(p=>p.Id==id,cancellationToken);
            return result;

        }

        public async Task<Order> GetOrderByNameAsync(string name,CancellationToken cancellationToken)
        {
            var result= await _writeDbContext.Orders.FirstOrDefaultAsync(p=>p.Name==name, cancellationToken);
            return result;
        }
    }
}
