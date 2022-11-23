using MediatR;

namespace AsuManagement.OrdersCrud.Services.Commands.GetOne.Orders
{
    public class GetOrderCommand : IRequest<GetOrderOutput>
    {
        public int Id { get; }

        public GetOrderCommand(int id) {
            Id = id;
        }
    }
}