using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Shared.Abstractions.Exceptions;

namespace OrderManagement.Application.Exceptions
{
    public class OrderAlreadyExistException:OrderManagementException
    {
        public string Name {  get; }   

        public OrderAlreadyExistException(string name):base($"Order with this name '{name}' is already exist")
        {
            Name= name;
        }
    }
}
