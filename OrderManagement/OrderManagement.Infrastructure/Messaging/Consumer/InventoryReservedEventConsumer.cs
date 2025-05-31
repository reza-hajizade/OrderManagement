using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Infrastructure.EF.Context;
using InventoryManagement.Shared.Contracts.Events;
using OrderManagement.Domain.Enums;
using OrderManagement.Application.Commands;
using MediatR;


namespace OrderManagement.Infrastructure.Messaging.Consumer
{
    public class InventoryReservedEventConsumer(WriteDbContext context,
        IMediator mediator) : IConsumer<InventoryReservedEvent>
    {
        private readonly WriteDbContext _context = context;
        private readonly IMediator _mediator=mediator;

        public async Task Consume(ConsumeContext<InventoryReservedEvent> context)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(p => p.Id == context.Message.Id);

            if(order is null)
            {
                Console.WriteLine("order is null");
                return;
            }

           await _mediator.Send(new ConfirmStatusCommand(order.Id,order.Status));
           
        }
    }
}
