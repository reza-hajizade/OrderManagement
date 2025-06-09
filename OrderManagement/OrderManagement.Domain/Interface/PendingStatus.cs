using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Enums;

namespace OrderManagement.Domain.Interface
{
    public  class PendingStatus : OrderState
    {
        public  PendingStatus()
        {
        }

        public override void Confirm(Order order)
        {
            _order.SetStatus(OrderStatus.Confirmed);
        }

        public override void Failed(Order order)
        {
            order.SetStatus(OrderStatus.Failed);
        }

        
    }
}
