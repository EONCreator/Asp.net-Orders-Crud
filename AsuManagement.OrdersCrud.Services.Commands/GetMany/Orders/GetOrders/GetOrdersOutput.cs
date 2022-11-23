using AsuManagement.OrdersCrud.Domain.Core.Entities;

namespace AsuManagement.OrdersCrud.Services.Commands.GetMany.Orders
{
    public class GetOrdersOutput
    {
        public List<Order> Orders { get; }
        public List<string> Numbers { get; }
        public List<Provider> Providers { get; }
        public GetOrdersOutput(List<Order> orders, List<string> numbers, List<Provider> providers)
        {
            Orders = orders;
            Numbers = numbers;
            Providers = providers;
        }
    }
}
