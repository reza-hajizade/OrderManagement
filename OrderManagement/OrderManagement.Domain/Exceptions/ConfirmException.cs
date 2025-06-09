using OrderManagement.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Exceptions
{
    public class ConfirmException:OrderManagementException
    {
        public ConfirmException():base("Confirm Not Found")
        {
            
        }
    }
}
