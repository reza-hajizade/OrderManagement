using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Enums;

namespace OrderManagement.Domain.Interface
{
    public  class PendingStatus : IOrderState
    {
        public void Confirm(Order order)
        {
           order.SetStatus(OrderStatus.Confirmed);
        }

        public void Failed(Order order)
        {
           order.SetStatus(OrderStatus.Failed);
        }
    }
}
