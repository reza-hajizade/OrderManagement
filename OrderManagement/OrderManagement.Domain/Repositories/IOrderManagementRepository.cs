using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Domain.Repositories
{
    public interface IOrderManagementRepository
    {
        Task AddAsync(Order order);
        Task<Order> GEtOrderById(int id);
    }
}
