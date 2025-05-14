using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Commands
{
    public record CreateOrderCommand(string Name,int Quantity):IRequest;
    
}
