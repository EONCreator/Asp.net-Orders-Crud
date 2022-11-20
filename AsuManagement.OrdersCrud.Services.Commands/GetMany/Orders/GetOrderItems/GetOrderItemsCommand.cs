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
    public class GetOrderItemsCommand : GetManyCommand<OrderItem>
    {
        public int OrderId { get; set; }
        public string? Name { get; set; }
        public string? Unit { get; set; }

        public GetOrderItemsCommand(int orderId, string? name, string unit) {
            OrderId = orderId;
            Name = name;
            Unit = unit;
        }
    }
}