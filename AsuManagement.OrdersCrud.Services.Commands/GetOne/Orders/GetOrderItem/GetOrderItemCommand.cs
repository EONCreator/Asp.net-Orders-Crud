using MediatR;

namespace AsuManagement.OrdersCrud.Services.Commands.GetOne.Orders
{
    public class GetOrderItemCommand : IRequest<GetOrderItemOutput>
    {
        public int Id { get; }

        public GetOrderItemCommand(int id) {
            Id = id;
        }
    }
}