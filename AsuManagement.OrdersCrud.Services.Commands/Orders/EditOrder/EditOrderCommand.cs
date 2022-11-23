using MediatR;

namespace AsuManagement.OrdersCrud.Services.Commands.Orders.EditOrder
{
    public class EditOrderCommand : IRequest<EditOrderOutput>
    {
        public int Id { get; }
        public string? Number { get; }
        public DateTime? Date { get; }
        public int? ProviderId { get; }

        public EditOrderCommand(int id, string? number, DateTime? date, int? providerId)
        {
            Id = id;
            Number = number;
            Date = date;
            ProviderId = providerId;
        }
    }
}
