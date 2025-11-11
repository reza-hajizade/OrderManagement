using OrderManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Entities
{
    public class OrderReadModel
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public int Quantity { get; set; }
        public OrderStatus Status { get; set; }
    }
}
