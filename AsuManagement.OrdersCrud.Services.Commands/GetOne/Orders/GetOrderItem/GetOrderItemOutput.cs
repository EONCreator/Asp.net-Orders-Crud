using AsuManagement.OrdersCrud.Domain.Core.Entities;

namespace AsuManagement.OrdersCrud.Services.Commands.GetOne.Orders
{
    public class GetOrderItemOutput
    {
        public OrderItem OrderItem { get; }
        public GetOrderItemOutput(OrderItem orderItem)
        {
            OrderItem = orderItem;
        }
    }
}
