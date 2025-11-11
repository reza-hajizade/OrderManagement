using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Interface;
using OrderManagement.Domain.Repositories;
using OrderManagement.Infrastructure.UnitOfWork;

namespace OrderManagement.Application.Commands.Handlers
{
    public class ConfirmStatusHandler : IRequestHandler<ConfirmStatusCommand>
    {
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ConfirmStatusHandler(IOrderWriteRepository orderWriteRepository,
            IUnitOfWork unitOfWork)
        {
            _orderWriteRepository = orderWriteRepository;
            _unitOfWork= unitOfWork;
        }

        public async Task Handle(ConfirmStatusCommand request, CancellationToken cancellationToken)
        {

           var order=await _orderWriteRepository.GetOrderById(request.Id);
            order.SetCurrentState();
            order.Confirm();
           await _unitOfWork.SaveChangeAsync(cancellationToken);
        }
    }
}
