using MediatR;
using AsuManagement.OrdersCrud.Domain.Interfaces;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using AsuManagement.OrdersCrud.Domain.Core.Errors;

namespace AsuManagement.OrdersCrud.Services.Commands.Orders.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, CreateOrderOutput>
    {
        private readonly IEntityRepository _repository;

        public CreateOrderHandler(IEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateOrderOutput> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            await using var unitOfWork = _repository.CreateUnitOfWork();

            var checkOrder = _repository.Entity<Order>()
                .Any(o => o.Number == request.Number && o.ProviderId == request.ProviderId);
            if (checkOrder == true)
                return CreateOrderOutput.Failure(OrderErrors.AlreadyExists);

            var order = new Order(request.Number, request.Date);

            var provider = await _repository.Entity<Provider>()
                .FirstOrDefaultAsync(p => p.Id == request.ProviderId);
            if (provider == null)
                return CreateOrderOutput.Failure(ProviderErrors.NotFound);

            order.SetProvider(provider);

            _repository.Entity<Order>().Add(order);

            await unitOfWork.Commit();

            return CreateOrderOutput.Success(order.Id);
        }
    }
}
