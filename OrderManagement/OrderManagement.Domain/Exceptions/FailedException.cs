using OrderManagement.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Exceptions
{
    public class FailedException:OrderManagementException
    {
        public FailedException():base("Failed Not Found")
        {
            
        }
    }
}
