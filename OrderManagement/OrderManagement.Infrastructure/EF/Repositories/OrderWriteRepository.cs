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
        public async Task AddAsync(Order order)
        {
           await _writeDbContext.Orders.AddAsync(order);
        }

        public async Task<Order> GetOrderById(int id)
        {
            var result= await _writeDbContext.Orders.FirstOrDefaultAsync(p=>p.Id==id);
            return result;

        }

        public async Task<Order> GetOrderByNameAsync(string name)
        {
            var result= await _writeDbContext.Orders.FirstOrDefaultAsync(p=>p.Name==name);
            return result;
        }
    }
}
