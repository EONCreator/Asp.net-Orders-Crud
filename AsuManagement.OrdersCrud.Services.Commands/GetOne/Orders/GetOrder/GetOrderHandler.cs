using AsuManagement.OrdersCrud.Domain.Interfaces;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AsuManagement.OrdersCrud.Domain.Core;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using AsuManagement.OrdersCrud.Services.Commands;

namespace AsuManagement.OrdersCrud.Presenters
{
    public class GetOrderHandler : GetOneHandler<GetOrderCommand, Order>
    {
        public GetOrderHandler(IEntityRepository repository) : base(repository) {
            
        }

        public override async Task<Order> Get(GetOrderCommand request)
        {
            var order = await Repository.Entity<Order>()
            .Include(o => o.Provider)
            .Include(o => o.OrderItems)

            .FirstOrDefaultAsync(o => o.Id == request.Id);

            return order;
        }
    }
}