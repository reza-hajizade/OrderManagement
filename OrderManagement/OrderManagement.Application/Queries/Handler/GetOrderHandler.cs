using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderManagement.Application.DTO;
using OrderManagement.Application.Exceptions;
using OrderManagement.Domain.Repositories;

namespace OrderManagement.Application.Queries.Handler
{
    public class GetOrderHandler : IRequestHandler<GetOrderQuery, GetOrderDto>
    {
        private readonly IOrderManagementRepository _orderManagementRepository;

        public GetOrderHandler(IOrderManagementRepository orderManagementRepository)
        {
            _orderManagementRepository = orderManagementRepository;
        }

        public async Task<GetOrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var Orders = await _orderManagementRepository.GetOrderById(request.Id);

            if (Orders is null)
            {
                throw new OrderNotFoundException();
            }

            return new GetOrderDto(
                 Orders.Name,
                 Orders.OrderDate,
                 Orders.Status
            );

        }
    }
}
