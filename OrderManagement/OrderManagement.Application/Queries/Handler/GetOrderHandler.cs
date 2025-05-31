using MediatR;
using OrderManagement.Application.DTO;
using OrderManagement.Application.Exceptions;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Repositories;


namespace OrderManagement.Application.Queries.Handler
{
    public sealed class GetOrderHandler : IRequestHandler<GetOrderQuery, GetOrderDto>
    {
        private readonly IOrderReadRepository _orderReadRepository;


        public GetOrderHandler(IOrderReadRepository orderReadRepository)
        {
            _orderReadRepository = orderReadRepository;
        }

        public async Task<GetOrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var Orders = await _orderReadRepository.GetOrderById(request.Id);

            if (Orders is null)
            {
                throw new OrderNotFoundException();
            }

            return new GetOrderDto(
                 Orders.Name,
                 Orders.Quantity,
                 Orders.Status
            );

        }
    }
}
