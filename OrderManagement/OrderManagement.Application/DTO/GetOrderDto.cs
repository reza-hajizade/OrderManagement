using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Domain.Enums;

namespace OrderManagement.Application.DTO
{
    public record GetOrderDto(
        string Name,
        int Quantity,
        OrderStatus Status
        );
    
}
