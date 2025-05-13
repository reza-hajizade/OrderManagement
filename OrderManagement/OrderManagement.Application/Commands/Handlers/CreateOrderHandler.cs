using MediatR;
using OrderManagement.Application.Exceptions;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Repositories;
using OrderManagement.Infrastructure.UnitOfWork;

namespace OrderManagement.Application.Commands.Handlers
{
    public class CreateOrderHandler: IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderManagementRepository _orderManagementRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateOrderHandler(IOrderManagementRepository orderManagementRepository,
            IUnitOfWork unitOfWork)
        {
            _orderManagementRepository = orderManagementRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task Handle(CreateOrderCommand command,CancellationToken  cancellationToken)
        {
            var existingOrder = await _orderManagementRepository.GetOrderByNameAsync(command.Name);

            if (existingOrder !=null)
            {
                throw new OrderAlreadyExistException(command.Name);
            }

            var newOrder = Order.Create(command.Name);  

            await _orderManagementRepository.AddAsync(newOrder);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
