using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Domain.Enums;

namespace OrderManagement.Domain.Entities
{
    public class Order
    {
        public const string TableName = "Orders";
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime OrderDate { get; private set; }
        public decimal TotalAmount { get; private set; } = 0;  
        public OrderStatus Status { get; private set; }

       // public List<OrderItem> Items { get; private set; }


        public static Order Create(string name)
        {
            return new Order
            {
              //  Items = items,
                Status = OrderStatus.Pending,
                OrderDate = DateTime.UtcNow,
                Name = name
            };
        }

    }


}
