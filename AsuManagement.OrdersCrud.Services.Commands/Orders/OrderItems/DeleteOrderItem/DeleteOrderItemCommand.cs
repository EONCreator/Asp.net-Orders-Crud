using AsuManagement.OrdersCrud.Domain.Interfaces.Results;
using MediatR;

namespace AsuManagement.OrdersCrud.Services.Commands.OrderItems.DeleteOrderItem
{
    public class DeleteOrderItemCommand : IRequest<SucceededResult>
    {
        public int Id { get; }

        public DeleteOrderItemCommand(int id)
        {
            Id = id;
        }
    }
}
