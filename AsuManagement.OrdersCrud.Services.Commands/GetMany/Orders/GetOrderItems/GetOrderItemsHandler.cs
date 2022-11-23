using AsuManagement.OrdersCrud.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AsuManagement.OrdersCrud.Domain.Core.Entities;

namespace AsuManagement.OrdersCrud.Services.Commands.GetMany.Orders
{
    public class GetOrderItemsHandler : IRequestHandler<GetOrderItemsCommand, GetOrderItemsOutput>
    {
        private readonly IEntityRepository _repository;

        public GetOrderItemsHandler(IEntityRepository repository) {
            _repository = repository;
        }

        public async Task<GetOrderItemsOutput> Handle(GetOrderItemsCommand request, CancellationToken cancellationToken)
        {
            var orderItems = _repository.Entity<OrderItem>()
                .Where(o => o.OrderId == request.OrderId);

            if (request.Name != null)
                orderItems = orderItems.Where(o => o.Name.ToLower()
                    .Contains(request.Name.ToLower()));
                
            if (request.Unit != null)
                orderItems = orderItems.Where(o => o.Unit.ToLower()
                    .Contains(request.Unit.ToLower()));

            return new GetOrderItemsOutput(await orderItems.ToListAsync());
        }
    }
}