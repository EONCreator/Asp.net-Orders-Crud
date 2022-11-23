using AsuManagement.OrdersCrud.Domain.Interfaces;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AsuManagement.OrdersCrud.Domain.Core;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using AsuManagement.OrdersCrud.Services.Commands;
using System.Linq;

namespace AsuManagement.OrdersCrud.Services.Commands.Orders
{
    public class GetOrdersCommand : IRequest<GetOrdersOutput>
    {
        public List<string> Numbers { get; }
        public List<int> Providers { get; }
        public DateTime? DateFrom { get; }
        public DateTime? DateTo { get; }

        public GetOrdersCommand(List<string> numbers, List<int> providers, DateTime? dateFrom, DateTime? dateTo) {
            Numbers = numbers;
            Providers = providers;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
    }
}