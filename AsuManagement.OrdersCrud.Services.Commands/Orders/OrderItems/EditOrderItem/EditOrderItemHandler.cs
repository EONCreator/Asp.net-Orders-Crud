using MediatR;
using AsuManagement.OrdersCrud.Domain.Interfaces;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using AsuManagement.OrdersCrud.Domain.Core.Errors;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;

namespace AsuManagement.OrdersCrud.Services.Commands.Orders.EditOrderItem
{
    public class EditOrderItemHandler : IRequestHandler<EditOrderItemCommand, EntityIdOutput>
    {
        private readonly IEntityRepository _repository;

        public EditOrderItemHandler(IEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<EntityIdOutput> Handle(EditOrderItemCommand request, CancellationToken cancellationToken)
        {
            await using var unitOfWork = _repository.CreateUnitOfWork();

            var orderItem = await _repository.Entity<OrderItem>().FirstOrDefaultAsync(o => o.Id == request.Id);
            if (orderItem == null)
                return EntityIdOutput.Failure(OrderErrors.OrderItemNotFound);

            if (request.Name != null)
            {
                if (await _repository.Entity<Order>()
                    .AnyAsync(o => o.Id == orderItem.OrderId && o.Number == request.Name))
                    return EntityIdOutput.Failure(OrderErrors.ItemNameSameWithOrderName);

                orderItem.SetName(request.Name);
            }

            if (request.Quantity != null)
                orderItem.SetQuantity(request.Quantity.Value);

            if (request.Unit != null)
                orderItem.SetUnit(request.Unit);

            await unitOfWork.Commit();

            return EntityIdOutput.Success(orderItem.Id);
        }
    }
}
