using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Repositories
{
    public interface IOrderWriteRepository
    {
        Task AddAsync(Order order,CancellationToken cancellationToken);
        Task<Order> GetOrderById(Guid id);
        Task<Order> GetOrderByNameAsync(string name,CancellationToken cancellationToken);
    }
}
