using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Domain.Exceptions;

namespace OrderManagement.Domain.Entities
{
    public class OrderItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
      

        public OrderItem(string Name,int Quantity)
        {
            if(string.IsNullOrEmpty(Name))
            {
                throw new OrederItemException();
            }
        }
    }
}
