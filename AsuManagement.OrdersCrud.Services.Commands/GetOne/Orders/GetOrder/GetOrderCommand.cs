using AsuManagement.OrdersCrud.Domain.Core.Entities;
using MediatR;

namespace AsuManagement.OrdersCrud.Services.Commands.GetOne.Orders
{
    public class GetOrderCommand : IRequest<Order>
    {
        public int Id { get; }

        public GetOrderCommand(int id) {
            Id = id;
        }
    }
}