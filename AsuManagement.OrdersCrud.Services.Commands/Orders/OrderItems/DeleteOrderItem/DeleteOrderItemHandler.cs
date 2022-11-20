using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AsuManagement.OrdersCrud.Domain.Interfaces;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AsuManagement.OrdersCrud.Services.Commands.OrderItems.DeleteOrderItem
{
    public class DeleteOrderItemHandler : IRequestHandler<DeleteOrderItemCommand, SucceededResult>
    {
        private readonly IEntityRepository _repository;

        public DeleteOrderItemHandler(IEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<SucceededResult> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            await using var unitOfWork = _repository.CreateUnitOfWork();

            var orderItem = await _repository.Entity<OrderItem>()
                .FirstOrDefaultAsync(o => o.Id == request.Id);
            if (orderItem == null)
                return SucceededResult.Failure("Элемент заказа не найден");

            _repository.Entity<OrderItem>().Remove(orderItem);

            await unitOfWork.Commit();

            return SucceededResult.Success;
        }
    }
}
