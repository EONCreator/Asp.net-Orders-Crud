using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;
using MediatR;

namespace AsuManagement.OrdersCrud.Services.Commands.Orders.AddItemToOrder
{
    public class AddItemToOrderOutput : SucceededResult
    {
        public int? CreatedOrderItemId { get; }

        public static AddItemToOrderOutput Success(int? createdOrderItemId) => new(true, createdOrderItemId);
        public static AddItemToOrderOutput Failure(string error) => new(false, null, error);

        public AddItemToOrderOutput(bool succeeded, int? createdOrderItemId, string? error = null)
            : base(succeeded, error)
        {
            CreatedOrderItemId = createdOrderItemId;
        }
    }
}
