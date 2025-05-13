using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Shared.Abstractions.Exceptions;

namespace OrderManagement.Domain.Exceptions
{
    public class OrederItemException : OrderManagementException
    {
        public OrederItemException() : base("OrderItem can not be empty")
        {
        }
    }
}
