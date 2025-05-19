using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Shared.Contracts.Events;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Commands;
using OrderManagement.Infrastructure.EF.Context;

namespace OrderManagement.Infrastructure.Messaging.Consumer
{
    public class InventoryFailedEventConsumer(OrderManagementDbContext orderManagementDbContext,
        IMediator mediator) : IConsumer<InventoryFailedEvent>
    {

        private readonly OrderManagementDbContext _orderManagementDbContext=orderManagementDbContext;
        private readonly IMediator _mediator= mediator;

        public async Task Consume(ConsumeContext<InventoryFailedEvent> context)
        {
            var order = await _orderManagementDbContext.Orders.FirstOrDefaultAsync(p => p.Id == context.Message.Id);

            if (order is null)
            {
                Console.WriteLine("order is null");
                return;
            }

            await _mediator.Send(new FailedStatusCommand(order.Id, order.Status));

        }
    }
}
