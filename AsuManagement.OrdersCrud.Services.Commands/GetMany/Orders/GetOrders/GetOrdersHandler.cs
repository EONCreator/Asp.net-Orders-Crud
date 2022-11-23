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

            if (request.Numbers != null)
            {
                var numbersToFilter = request.Numbers.Split(",").ToList();
                orders = orders.Where(o => numbersToFilter.Any(n => o.Number == n));
            }

            if (request.Providers != null)
            {
                var providersToFilter = request.Providers.Split(",").Select(Int32.Parse).ToList();
                orders = orders.Where(o => providersToFilter.Any(p => o.ProviderId == p));
            }

            var dateFrom = request.DateFrom ?? DateTime.Now.AddMonths(-1);
            orders = orders.Where(o => o.Date.Date >= dateFrom);

            var dateTo = request.DateTo ?? DateTime.Now;
            orders = orders.Where(o => o.Date.Date <= dateTo);

            var items = await orders.ToListAsync();
            return new GetOrdersOutput(items, numbers, providers, items.Count);
        }
    }
}