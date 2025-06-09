using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Interface;

namespace OrderManagement.Domain.Entities
{
    public  class Order
    {
      
        public int Id { get; set; }
        public string Name { get;private set; }
        public int Quantity {  get;private set; }
        public DateTime OrderDate { get; private set; }
        public OrderStatus Status { get; private set; }

        private OrderState _state ;
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

        public void SetCurrentState()
        {
            switch (this.Status)
            {
                case OrderStatus.Pending:
                    this._state = new PendingStatus();
                    this._state.SetOrder(this);
                    break;
                case OrderStatus.Confirmed:
                    this._state = new ConfirmedStatus();
                    this._state.SetOrder(this);
                    break;
                case OrderStatus.Failed:
                    this._state = new FailedStatus();
                    this._state.SetOrder(this);
                    break;
                default:
                    break;
            }
        }

        public void Confirm()
        {

            _state?.Confirm(this);
        }

        public void Failed()
        {
             _state?.Failed(this);
        }

        public void SetStatus(OrderStatus status)
        {
            Status =status;
        }   
    }

}
