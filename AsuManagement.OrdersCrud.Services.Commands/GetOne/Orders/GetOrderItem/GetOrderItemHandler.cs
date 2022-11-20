using AsuManagement.OrdersCrud.Domain.Interfaces;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AsuManagement.OrdersCrud.Domain.Core;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using AsuManagement.OrdersCrud.Services.Commands;

namespace AsuManagement.OrdersCrud.Presenters
{
    public class GetOrderItemHandler : GetOneHandler<GetOrderItemCommand, OrderItem>
    {
        public GetOrderItemHandler(IEntityRepository repository) : base(repository) {
            
        }

        public override async Task<OrderItem> Get(GetOrderItemCommand request)
        {
            var orderItem = await Repository.Entity<OrderItem>()
                .FirstOrDefaultAsync(o => o.Id == request.Id);

            return orderItem;
        }
    }
}