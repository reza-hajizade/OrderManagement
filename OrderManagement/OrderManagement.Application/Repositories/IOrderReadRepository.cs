using OrderManagement.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Repositories
{
    public interface IOrderReadRepository
    {
        Task<GetOrderDto> GetOrderById(int id);
    }
}
