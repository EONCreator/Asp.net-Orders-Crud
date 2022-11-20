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
    public class GetOrderItemsHandler : GetManyHandler<GetOrderItemsCommand, OrderItem>
    {
        public GetOrderItemsHandler(IEntityRepository repository) : base(repository) {
        }

        public override async Task<List<OrderItem>> Get(GetOrderItemsCommand request)
        {
            var orderItems = Repository.Entity<OrderItem>()
                .Where(o => o.OrderId == request.OrderId);

            if (request.Name != null)
                orderItems = orderItems.Where(o => o.Name.ToLower()
                    .Contains(request.Name.ToLower()));
                
            if (request.Unit != null)
                orderItems = orderItems.Where(o => o.Unit.ToLower()
                    .Contains(request.Unit.ToLower()));
            
            return await orderItems.ToListAsync();;
        }
    }
}