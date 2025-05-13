using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Repositories;
using OrderManagement.Infrastructure.EF.Context;

namespace OrderManagement.Infrastructure.Repositories
{
    public class OrderManagementRepository : IOrderManagementRepository
    {
        private readonly OrderManagementDbContext _context;
        public OrderManagementRepository(OrderManagementDbContext context)
        {
            _context = context;         
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public async Task<Order> GEtOrderById(int id)
        {
            var result=await _context.Orders.FirstOrDefaultAsync(p=>p.Id == id);
            return result;

        }
    }
}
