using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using OrderManagement.Application.Interfaces;
using OrderManagement.Shared.Contracts.Events;

namespace OrderManagement.Infrastructure.Messaging.Publishers
{
    public class OrderCreatedEventPublisher : IOrderCreatedEventPublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public OrderCreatedEventPublisher(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        public async Task PublishAsync(OrderCreatedEvent @event)
        {
           await _publishEndpoint.Publish(@event);
        }
    }
}
