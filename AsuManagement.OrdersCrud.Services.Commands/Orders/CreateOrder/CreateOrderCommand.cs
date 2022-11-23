using MediatR;

namespace AsuManagement.OrdersCrud.Services.Commands.Orders.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderOutput>
    {
        public string Number { get; }
        public DateTime Date { get; }
        public int ProviderId { get; }

        public CreateOrderCommand(string number, DateTime date, int providerId)
        {
            Number = number;
            Date = date;
            ProviderId = providerId;
        }
    }
}
