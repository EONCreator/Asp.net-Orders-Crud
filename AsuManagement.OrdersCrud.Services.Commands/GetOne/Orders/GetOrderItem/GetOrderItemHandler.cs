using Microsoft.EntityFrameworkCore;
using MediatR;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using AsuManagement.OrdersCrud.Domain.Interfaces;

namespace AsuManagement.OrdersCrud.Services.Commands.GetOne.Orders
{
    public class GetOrderItemHandler : IRequestHandler<GetOrderItemCommand, GetOrderItemOutput>
    {
        private readonly IEntityRepository _repository;

        public GetOrderItemHandler(IEntityRepository repository) {
            _repository = repository;
        }

        public async Task<GetOrderItemOutput> Handle(GetOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = await _repository.Entity<OrderItem>()
                .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

            return new GetOrderItemOutput(orderItem);
        }
    }
}