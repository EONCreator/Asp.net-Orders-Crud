using MediatR;
using AsuManagement.OrdersCrud.Domain.Interfaces;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using AsuManagement.OrdersCrud.Domain.Core.Errors;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;

namespace AsuManagement.OrdersCrud.Services.Commands.Orders.EditOrder
{
    public class EditOrderHandler : IRequestHandler<EditOrderCommand, EntityIdOutput>
    {
        private readonly IEntityRepository _repository;

        public EditOrderHandler(IEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<EntityIdOutput> Handle(EditOrderCommand request, CancellationToken cancellationToken)
        {
            await using var unitOfWork = _repository.CreateUnitOfWork();

            var order = await _repository.Entity<Order>().FirstOrDefaultAsync(o => o.Id == request.Id);
            if (order == null)
                return EntityIdOutput.Failure(OrderErrors.NotFound);

            var number = request.Number != null ? request.Number : order.Number;
            var providerId = request.ProviderId != null ? request.ProviderId : order.ProviderId;

            if (await _repository.Entity<Order>()
                .AnyAsync(o => o.Number == number
                && o.ProviderId == providerId
                && o.Id != order.Id))
                return EntityIdOutput.Failure(OrderErrors.AlreadyExists);
            
            if (await _repository.Entity<OrderItem>()
                .AnyAsync(o => o.OrderId == order.Id && o.Name == request.Number))
                return EntityIdOutput.Failure(OrderErrors.ContainsOrderItemWithSameName);

            if (request.ProviderId != null)
            {
                var provider = await _repository.Entity<Provider>().FirstOrDefaultAsync(p => p.Id == request.ProviderId);
                if (provider == null)
                    return EntityIdOutput.Failure(ProviderErrors.NotFound);

                order.SetProvider(provider);
            }

            order.SetNumber(number);

            if (request.Date != null)
                order.SetDate(request.Date.Value);

            await unitOfWork.Commit();

            return EntityIdOutput.Success(order.Id);
        }
    }
}
