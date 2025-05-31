using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderManagement.Domain.Interface;
using OrderManagement.Domain.Repositories;
using OrderManagement.Infrastructure.UnitOfWork;

namespace OrderManagement.Application.Commands.Handlers
{
    public class FailedStatusHandler: IRequestHandler<FailedStatusCommand>
    {
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IUnitOfWork _unitOfWork;
        public FailedStatusHandler(IOrderWriteRepository orderWriteRepository,
            IUnitOfWork unitOfWork)
        {
            _orderWriteRepository = orderWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(FailedStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderWriteRepository.GetOrderById(request.id);
            order.SetState(new PendingStatus());
            order.Failed();
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
