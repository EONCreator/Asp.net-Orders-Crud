using AsuManagement.OrdersCrud.Domain.Core.Entities;

namespace AsuManagement.OrdersCrud.Services.Commands.GetOne.Orders
{
    public class GetOrderOutput
    {
        public Order Order { get; }
        public GetOrderOutput(Order order)
        {
            Order = order;
        }
    }
}
