using OrderManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.EF.Models
{
    public class OrderReadModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Quantity { get; set; }
        public OrderStatus Status { get; set; }
    }
}
