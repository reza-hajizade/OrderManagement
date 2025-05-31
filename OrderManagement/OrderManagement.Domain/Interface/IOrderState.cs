using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Enums;

namespace OrderManagement.Domain.Interface
{
    public interface IOrderState
    {
        void Confirm(Order order);
        void Failed(Order order);
    }
}
