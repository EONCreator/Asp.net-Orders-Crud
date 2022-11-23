using MediatR;

namespace AsuManagement.OrdersCrud.Services.Commands.GetMany.Orders
{
    public class GetOrdersCommand : IRequest<GetOrdersOutput>
    {
        public string? Numbers { get; }
        public string? Providers { get; }
        public DateTime? DateFrom { get; }
        public DateTime? DateTo { get; }

        public GetOrdersCommand(string? numbers, string? providers, DateTime? dateFrom, DateTime? dateTo) {
            Numbers = numbers;
            Providers = providers;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
    }
}