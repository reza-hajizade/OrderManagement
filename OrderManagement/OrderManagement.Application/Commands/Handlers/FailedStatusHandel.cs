using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderManagement.Domain.Repositories;
using OrderManagement.Infrastructure.UnitOfWork;

namespace OrderManagement.Application.Commands.Handlers
{
    public class FailedStatusHandel: IRequestHandler<FailedStatusCommand>
    {
        private readonly IOrderManagementRepository _orderManagementRepository;
        private readonly IUnitOfWork _unitOfWork;
        public FailedStatusHandel(IOrderManagementRepository orderManagementRepository,
            IUnitOfWork unitOfWork)
        {
            _orderManagementRepository = orderManagementRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(FailedStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderManagementRepository.GetOrderById(request.id);

            order.FailedStatus(order.Status);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
