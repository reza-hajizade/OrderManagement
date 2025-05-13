using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Shared.Abstractions.Exceptions
{
    public abstract class OrderManagementException:Exception
    {
        protected OrderManagementException(string message) :base(message) { }      
    }
}
