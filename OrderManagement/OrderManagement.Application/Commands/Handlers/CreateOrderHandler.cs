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
        private readonly IOrderManagementRepository _orderManagementRepository;
        private readonly IOrderCreatedEventPublisher _orderCreatedEventPublisher;
        private readonly IUnitOfWork _unitOfWork;
        public CreateOrderHandler(IOrderManagementRepository orderManagementRepository,
            IUnitOfWork unitOfWork,
            IOrderCreatedEventPublisher orderCreatedEventPublisher)
        {
            _orderManagementRepository = orderManagementRepository;
            _unitOfWork = unitOfWork;
            _orderCreatedEventPublisher = orderCreatedEventPublisher;
        }


        public async Task Handle(CreateOrderCommand command,CancellationToken  cancellationToken)
        {
            var existingOrder = await _orderManagementRepository.GetOrderByNameAsync(command.Name);

            var newOrder = Order.Create(command.Name,command.Quantity);  

            await _orderManagementRepository.AddAsync(newOrder);


            await _unitOfWork.SaveChangeAsync();

            await _orderCreatedEventPublisher.PublishAsync(new OrderCreatedEvent(newOrder.Id,newOrder.Name,newOrder.Quantity,DateTime.UtcNow));

        }
    }
}
