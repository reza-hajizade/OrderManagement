using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Shared.Contracts.Events;

namespace OrderManagement.Application.Interfaces
{
    public interface IOrderCreatedEventPublisher
    {
        Task PublishAsync(OrderCreatedEvent @event);
    }
}
