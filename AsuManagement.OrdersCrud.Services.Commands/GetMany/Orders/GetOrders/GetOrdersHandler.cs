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
    public class GetOrdersHandler : GetManyHandler<GetOrdersCommand, Order>
    {
        public GetOrdersHandler(IEntityRepository repository) : base(repository) {
        }

        public override async Task<List<Order>> Get(GetOrdersCommand request)
        {
            var orders = Repository.Entity<Order>()
                .Include(o => o.OrderItems)
                .Include(o => o.Provider)
                .AsQueryable();

            if (request.Number != null)
                orders = orders.Where(o => o.Number.Contains(request.Number));
                
            if (request.ProviderId != null)
                orders = orders.Where(o => o.ProviderId == request.ProviderId);

            if (request.DateFrom != null && request.DateTo != null)
                orders = orders.Where(o => o.Date.Date >= request.DateFrom.Value.Date);

            if (request.DateTo != null)
                orders = orders.Where(o => o.Date.Date <= request.DateTo.Value.Date);
            
            return await orders.ToListAsync();;
        }
    }
}