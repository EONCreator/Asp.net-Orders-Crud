using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace AsuManagement.OrdersCrud.Services.Commands.Orders.EditOrderItem
{
    public class EditOrderItemCommand : IRequest<EditOrderItemOutput>
    {
        public int Id { get; }
        public string? Name { get; }
        public decimal? Quantity { get; }
        public string? Unit { get; }

        public EditOrderItemCommand(int id, string? name, decimal? quantity, string? unit)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }
    }
}
