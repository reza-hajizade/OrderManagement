using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderManagement.Domain.Enums;

namespace OrderManagement.Application.Commands
{
    public record ConfirmStatusCommand(Guid Id,OrderStatus OrderStatus):IRequest;
    
}
