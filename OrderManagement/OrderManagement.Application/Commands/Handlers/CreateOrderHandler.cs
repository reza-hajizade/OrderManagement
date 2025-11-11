using MediatR;
using OrderManagement.Application.Exceptions;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Repositories;
using OrderManagement.Infrastructure.UnitOfWork;
using OrderManagement.Shared.Contracts.Events;

namespace OrderManagement.Application.Commands.Handlers
{
    public class CreateOrderHandler: IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IOrderCreatedEventPublisher _orderCreatedEventPublisher;
        private readonly IUnitOfWork _unitOfWork;
        public CreateOrderHandler(IOrderWriteRepository orderWriteRepository,
            IUnitOfWork unitOfWork,
            IOrderCreatedEventPublisher orderCreatedEventPublisher)
        {
            _orderWriteRepository = orderWriteRepository;
            _unitOfWork = unitOfWork;
            _orderCreatedEventPublisher = orderCreatedEventPublisher;
        }


        public async Task Handle(CreateOrderCommand command,CancellationToken  cancellationToken)
        {
            var existingOrder = await _orderWriteRepository.GetOrderByNameAsync(command.Name);

            var newOrder = Order.Create(command.Name,command.Quantity);  

            await _orderWriteRepository.AddAsync(newOrder,cancellationToken);

            await _unitOfWork.SaveChangeAsync(cancellationToken);
            await _orderCreatedEventPublisher.PublishAsync(new OrderCreatedEvent(newOrder.Id,newOrder.Name,newOrder.Quantity,DateTime.UtcNow));

        }
    }
}
