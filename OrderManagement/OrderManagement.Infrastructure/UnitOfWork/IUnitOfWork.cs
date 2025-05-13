using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Infrastructure.EF.Context;

namespace OrderManagement.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        
        Task<int> SaveChangeAsync();
        
    }
}
