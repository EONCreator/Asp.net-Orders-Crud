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

namespace AsuManagement.OrdersCrud.Services.Commands.Orders.DeleteOrder
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, SucceededResult>
    {
        private readonly IEntityRepository _repository;

        public DeleteOrderHandler(IEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<SucceededResult> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            await using var unitOfWork = _repository.CreateUnitOfWork();

            var order = await _repository.Entity<Order>()
                .FirstOrDefaultAsync(o => o.Id == request.Id);
            if (order == null)
                return SucceededResult.Failure("Заказ не найден");

            _repository.Entity<Order>().Remove(order);

            await unitOfWork.Commit();

            return SucceededResult.Success;
        }
    }
}
