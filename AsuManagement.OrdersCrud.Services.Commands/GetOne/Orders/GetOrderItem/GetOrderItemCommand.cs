using AsuManagement.OrdersCrud.Domain.Core.Entities;
using MediatR;

namespace AsuManagement.OrdersCrud.Services.Commands.GetOne.Orders
{
    public class GetOrderItemCommand : IRequest<OrderItem>
    {
        public int Id { get; }

        public GetOrderItemCommand(int id) {
            Id = id;
        }
    }
}