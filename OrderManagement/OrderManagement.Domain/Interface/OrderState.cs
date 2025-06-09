using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Interface
{
    public abstract class OrderState
    {
        protected Order _order;
        protected OrderState()
        {
        }
        public void SetOrder(Order order)
        {
            this._order = order;
        }
        public virtual void Confirm(Order order) => throw new ConfirmException();
        public virtual void Failed(Order order) => throw new FailedException();



    }
}
