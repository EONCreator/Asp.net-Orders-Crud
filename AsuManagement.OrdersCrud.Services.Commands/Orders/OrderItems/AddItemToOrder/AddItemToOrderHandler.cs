using MediatR;
using AsuManagement.OrdersCrud.Domain.Interfaces;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using AsuManagement.OrdersCrud.Domain.Core.Errors;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;

namespace AsuManagement.OrdersCrud.Services.Commands.Orders.AddItemToOrder
{
    public class AddItemToOrderHandler : IRequestHandler<AddItemToOrderCommand, EntityIdOutput>
    {
        private readonly IEntityRepository _repository;

        public AddItemToOrderHandler(IEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<EntityIdOutput> Handle(AddItemToOrderCommand request, CancellationToken cancellationToken)
        {
            await using var unitOfWork = _repository.CreateUnitOfWork();

            var order = await _repository.Entity<Order>().FirstOrDefaultAsync(o => o.Id == request.OrderId);
            if (order == null)
                return EntityIdOutput.Failure(OrderErrors.NotFound);

            if (request.Name == order.Number)
                return EntityIdOutput.Failure(OrderErrors.ItemNameSameWithOrderName);

            var orderItem = new OrderItem(request.Name, request.Quantity, request.Unit);
            order.AddOrderItem(orderItem);

            await unitOfWork.Commit();

            return EntityIdOutput.Success(orderItem.Id);
        }
    }
}
