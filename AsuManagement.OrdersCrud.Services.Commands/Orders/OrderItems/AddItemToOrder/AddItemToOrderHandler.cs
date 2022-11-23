using MediatR;
using AsuManagement.OrdersCrud.Domain.Interfaces;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using AsuManagement.OrdersCrud.Domain.Core.Errors;

namespace AsuManagement.OrdersCrud.Services.Commands.Orders.AddItemToOrder
{
    public class AddItemToOrderHandler : IRequestHandler<AddItemToOrderCommand, AddItemToOrderOutput>
    {
        private readonly IEntityRepository _repository;

        public AddItemToOrderHandler(IEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddItemToOrderOutput> Handle(AddItemToOrderCommand request, CancellationToken cancellationToken)
        {
            await using var unitOfWork = _repository.CreateUnitOfWork();

            var order = await _repository.Entity<Order>().FirstOrDefaultAsync(o => o.Id == request.OrderId);
            if (order == null)
                return AddItemToOrderOutput.Failure(OrderErrors.NotFound);

            if (request.Name == order.Number)
                return AddItemToOrderOutput.Failure(OrderErrors.ItemNameSameWithOrderName);

            var orderItem = new OrderItem(request.Name, request.Quantity, request.Unit);
            order.AddOrderItem(orderItem);

            await unitOfWork.Commit();

            return AddItemToOrderOutput.Success(orderItem.Id);
        }
    }
}
