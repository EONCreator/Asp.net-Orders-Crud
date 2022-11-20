using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace AsuManagement.OrdersCrud.Services.Commands.Orders.AddItemToOrder
{
    public class AddItemToOrderCommand : IRequest<AddItemToOrderOutput>
    {
        public int OrderId { get; }
        public string Name { get; }
        public decimal Quantity { get; }
        public string Unit { get; }

        public AddItemToOrderCommand(int orderId, string name, decimal quantity, string unit)
        {
            OrderId = orderId;
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }
    }
}
