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
    public class GetOrderCommand : GetOneCommand<Order>
    {
        public int Id { get; }

        public GetOrderCommand(int id) {
            Id = id;
        }
    }
}