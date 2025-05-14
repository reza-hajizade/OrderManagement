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
        public string Name { get;private set; }
        public int Quantity {  get;private set; }
        public DateTime OrderDate { get; private set; }
        public OrderStatus Status { get; private set; }


        public static Order Create(string name,int quantity)
        {
            return new Order
            {
                Status = OrderStatus.Pending,
                OrderDate = DateTime.UtcNow,
                Name = name,
                Quantity=quantity
            };
        }

    }


}
