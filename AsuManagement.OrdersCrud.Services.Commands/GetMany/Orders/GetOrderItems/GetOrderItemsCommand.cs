using MediatR;

namespace AsuManagement.OrdersCrud.Services.Commands.GetMany.Orders
{
    public class GetOrderItemsCommand : IRequest<GetOrderItemsOutput>
    {
        public int OrderId { get; set; }
        public string? Name { get; set; }
        public string? Unit { get; set; }

        public GetOrderItemsCommand(int orderId, string? name, string unit) {
            OrderId = orderId;
            Name = name;
            Unit = unit;
        }
    }
}