using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;
using MediatR;

namespace AsuManagement.OrdersCrud.Services.Commands.Orders.EditOrder
{
    public class EditOrderOutput : SucceededResult
    {
        public int? EditedOrderId { get; }

        public static EditOrderOutput Success(int? editedOrderId) => new(true, editedOrderId);
        public static EditOrderOutput Failure(string error) => new(false, null, error);

        public EditOrderOutput(bool succeeded, int? editedOrderId, string? error = null)
            : base(succeeded, error)
        {
            EditedOrderId = editedOrderId;
        }
    }
}
