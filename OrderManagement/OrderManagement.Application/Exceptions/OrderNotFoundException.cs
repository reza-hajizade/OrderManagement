using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Shared.Abstractions.Exceptions;

namespace OrderManagement.Application.Exceptions
{
    public class OrderNotFoundException:OrderManagementException
    {
        public OrderNotFoundException():base("This Order Not Found")
        {
            
        }
    }
}
