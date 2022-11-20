using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;
using MediatR;

namespace AsuManagement.OrdersCrud.Services.Commands.Orders.EditOrderItem
{
    public class EditOrderItemOutput : SucceededResult
    {
        public int? EditedOrderItemId { get; }

        public static EditOrderItemOutput Success(int? editedOrderItemId) => new(true, editedOrderItemId);
        public static EditOrderItemOutput Failure(string error) => new(false, null, error);

        public EditOrderItemOutput(bool succeeded, int? editedOrderItemId, string? error = null)
            : base(succeeded, error)
        {
            EditedOrderItemId = editedOrderItemId;
        }
    }
}
