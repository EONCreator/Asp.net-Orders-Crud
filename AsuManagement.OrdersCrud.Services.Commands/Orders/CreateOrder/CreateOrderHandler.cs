using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AsuManagement.OrdersCrud.Domain.Interfaces;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

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
                return CreateOrderOutput.Failure("Заказ с таким номером и поставщиком уже существует");

            var order = new Order(request.Number, request.Date);
            var provider = await _repository.Entity<Provider>()
                .FirstOrDefaultAsync(p => p.Id == request.ProviderId);
            order.SetProvider(provider);

            _repository.Entity<Order>().Add(order);

            await unitOfWork.Commit();

            return CreateOrderOutput.Success(order.Id);
        }
    }
}
