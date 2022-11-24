using Microsoft.EntityFrameworkCore;
using MediatR;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using AsuManagement.OrdersCrud.Domain.Interfaces;

namespace AsuManagement.OrdersCrud.Services.Commands.GetOne.Orders
{
    public class GetOrderItemHandler : IRequestHandler<GetOrderItemCommand, OrderItem>
    {
        private readonly IEntityRepository _repository;

        public GetOrderItemHandler(IEntityRepository repository) {
            _repository = repository;
        }

        public async Task<OrderItem> Handle(GetOrderItemCommand request, CancellationToken cancellationToken)
        => await _repository.Entity<OrderItem>()
                .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);
    }
}