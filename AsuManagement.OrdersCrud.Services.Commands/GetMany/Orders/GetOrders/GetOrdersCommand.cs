using AsuManagement.OrdersCrud.Domain.Interfaces;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AsuManagement.OrdersCrud.Domain.Core;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using AsuManagement.OrdersCrud.Services.Commands;
using System.Linq;
using AsuManagement.OrdersCrud.Services.Commands.Orders.CreateOrder;

namespace AsuManagement.OrdersCrud.Domain.Interfaces.Results
{
    public class GetOrdersCommand : GetManyCommand<Order>
    {
        public string Number { get; }
        public int? ProviderId { get; }
        public DateTime? DateFrom { get; }
        public DateTime? DateTo { get; }

        public GetOrdersCommand(string number, int? providerId, DateTime? dateFrom, DateTime? dateTo) {
            Number = number;
            ProviderId = providerId;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
    }
}