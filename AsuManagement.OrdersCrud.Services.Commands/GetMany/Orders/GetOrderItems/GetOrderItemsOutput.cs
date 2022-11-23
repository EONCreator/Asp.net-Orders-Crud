using AsuManagement.OrdersCrud.Domain.Core.Entities;

namespace AsuManagement.OrdersCrud.Services.Commands.GetMany.Orders
{
    public class GetOrderItemsOutput
    {
        public List<OrderItem> OrderItems { get; }
        public GetOrderItemsOutput(List<OrderItem> orderItems)
        {
            OrderItems = orderItems;
        }
    }
}
