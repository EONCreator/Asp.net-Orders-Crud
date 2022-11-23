using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AsuManagement.OrdersCrud.Domain.Interfaces;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using AsuManagement.OrdersCrud.Domain.Core.Errors;
using AsuManagement.OrdersCrud.Services.Commands.Orders.EditOrder;
using AutoMapper.Execution;

namespace AsuManagement.OrdersCrud.Services.Commands.Orders.EditOrderItem
{
    public class EditOrderItemHandler : IRequestHandler<EditOrderItemCommand, EditOrderItemOutput>
    {
        private readonly IEntityRepository _repository;

        public EditOrderItemHandler(IEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<EditOrderItemOutput> Handle(EditOrderItemCommand request, CancellationToken cancellationToken)
        {
            await using var unitOfWork = _repository.CreateUnitOfWork();

            var orderItem = await _repository.Entity<OrderItem>().FirstOrDefaultAsync(o => o.Id == request.Id);
            if (orderItem == null)
                return EditOrderItemOutput.Failure(OrderErrors.OrderItemNotFound);

            if (request.Name != null)
            {
                if (await _repository.Entity<Order>()
                    .AnyAsync(o => o.Id == orderItem.OrderId && o.Number == request.Name))
                    return EditOrderItemOutput.Failure(OrderErrors.ItemNameSameWithOrderName);

                orderItem.SetName(request.Name);
            }

            if (request.Quantity != null)
                orderItem.SetQuantity(request.Quantity.Value);

            if (request.Unit != null)
                orderItem.SetUnit(request.Unit);

            await unitOfWork.Commit();

            return EditOrderItemOutput.Success(orderItem.Id);
        }
    }
}
