using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.DTO;
using OrderManagement.Application.Repositories;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Repositories;
using OrderManagement.Infrastructure.EF.Context;
using OrderManagement.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.EF.Repositories
{
    public class OrderReadRepository : IOrderReadRepository
    {
        private readonly ReadDbContext _readDbContext;
        public OrderReadRepository(ReadDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }
        public async Task<GetOrderDto> GetOrderById(int id)
        {
            var result = await _readDbContext.orderReadModels.FirstOrDefaultAsync(p => p.Id == id);
            return new GetOrderDto(
               result.Name,
               result.Quantity,
               result.Status
            );
        }
    }
}
