using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Shared.Contracts.Events
{
    public record OrderCreatedEvent(int Id,string Name,int Quantity, DateTime OccurredOn);
    
}
