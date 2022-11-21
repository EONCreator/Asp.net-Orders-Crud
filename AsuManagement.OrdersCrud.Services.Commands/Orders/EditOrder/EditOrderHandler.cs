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

namespace AsuManagement.OrdersCrud.Services.Commands.Orders.EditOrder
{
    public class EditOrderHandler : IRequestHandler<EditOrderCommand, EditOrderOutput>
    {
        private readonly IEntityRepository _repository;

        public EditOrderHandler(IEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<EditOrderOutput> Handle(EditOrderCommand request, CancellationToken cancellationToken)
        {
            await using var unitOfWork = _repository.CreateUnitOfWork();

            var order = await _repository.Entity<Order>().FirstOrDefaultAsync(o => o.Id == request.Id);
            if (order == null)
                return EditOrderOutput.Failure(OrderErrors.NotFound);

            var number = request.Number != null ? request.Number : order.Number;
            var providerId = request.ProviderId != null ? request.ProviderId : order.ProviderId;

            var checkingOrder = await _repository.Entity<Order>()
                .FirstOrDefaultAsync(o => o.Number == number
                && o.ProviderId == providerId
                && o.Id != order.Id);
            if (checkingOrder != null)
                return EditOrderOutput.Failure(OrderErrors.AlreadyExists);

            if (request.ProviderId != null)
            {
                var provider = await _repository.Entity<Provider>().FirstOrDefaultAsync(p => p.Id == request.ProviderId);
                if (provider == null)
                    return EditOrderOutput.Failure(ProviderErrors.NotFound);

                order.SetProvider(provider);
            }

            order.SetNumber(number);

            if (request.Date != null)
                order.SetDate(request.Date.Value);

            await unitOfWork.Commit();

            return EditOrderOutput.Success(order.Id);
        }
    }
}
