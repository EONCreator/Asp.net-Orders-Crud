using AsuManagement.OrdersCrud.Domain.Interfaces;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AsuManagement.OrdersCrud.Domain.Core;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using AsuManagement.OrdersCrud.Services.Commands;
using System.Linq;
using AsuManagement.OrdersCrud.Services.Commands.Orders.CreateOrder;
using AsuManagement.OrdersCrud.Services.Commands.Orders;

namespace AsuManagement.OrdersCrud.Services.Commands.Orders
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersCommand, GetOrdersOutput>
    {
        private readonly IEntityRepository _repository;

        public GetOrdersHandler(IEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetOrdersOutput> Handle(GetOrdersCommand request, CancellationToken cancellationToken)
        {
            var orders = _repository.Entity<Order>()
                .Include(o => o.OrderItems)
                .Include(o => o.Provider)
                .AsQueryable();

            var numbers = orders.Select(i => i.Number).Distinct().ToList();
            var providers = orders.Select(i => i.Provider).Distinct().ToList();

            if (request.Numbers.Count > 0)
                orders = orders.Where(o => request.Numbers.Any(n => o.Number == n));

            if (request.Providers.Count > 0)
                orders = orders.Where(o => request.Providers.Any(p => o.ProviderId == p));

            if (request.DateFrom != null && request.DateTo != null)
                orders = orders.Where(o => o.Date.Date >= request.DateFrom.Value.Date);

            if (request.DateTo != null)
                orders = orders.Where(o => o.Date.Date <= request.DateTo.Value.Date);

            var items = await orders.ToListAsync();
            return new GetOrdersOutput(items, numbers, providers, items.Count);
        }
    }
}