using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderManagement.Application.DTO;

namespace OrderManagement.Application.Queries
{
    public sealed record GetOrderQuery(Guid Id):IRequest<GetOrderDto>;
    
}
