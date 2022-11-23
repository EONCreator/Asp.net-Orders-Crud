using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;
using MediatR;

namespace AsuManagement.OrdersCrud.Services.Commands.Orders
{
    public class GetOrdersOutput : GetManyQueryResponse<Order>
    {
        public List<string> Numbers { get; }
        public List<Provider> Providers { get; }
        public GetOrdersOutput(List<Order> items, List<string> numbers, List<Provider> providers, int totalCount) : base(items, totalCount)
        {
            Numbers = numbers;
            Providers = providers;
        }
    }
}
