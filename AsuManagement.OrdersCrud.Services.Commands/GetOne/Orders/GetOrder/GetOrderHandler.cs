using AsuManagement.OrdersCrud.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AsuManagement.OrdersCrud.Domain.Core.Entities;

namespace AsuManagement.OrdersCrud.Services.Commands.GetOne.Orders
{
    public class GetOrderHandler : IRequestHandler<GetOrderCommand, Order>
    {
        private readonly IEntityRepository _repository;

        public GetOrderHandler(IEntityRepository repository) {
            _repository = repository;
        }

        public async Task<Order> Handle(GetOrderCommand request, CancellationToken cancellationToken)
        => await _repository.Entity<Order>()
            .Include(o => o.Provider)
            .Include(o => o.OrderItems)

            .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);
    }
}