using AsuManagement.OrdersCrud.Domain.Interfaces.Results;

namespace AsuManagement.OrdersCrud.Services.Commands.Orders.CreateOrder
{
    public class CreateOrderOutput : SucceededResult
    {
        public int? CreatedOrderId { get; }

        public static CreateOrderOutput Success(int? createdOrderId) => new(true, createdOrderId);
        public static CreateOrderOutput Failure(string error) => new(false, null, error);

        public CreateOrderOutput(bool succeeded, int? createdOrderId, string? error = null)
            : base(succeeded, error)
        {
            CreatedOrderId = createdOrderId;
        }
    }
}
