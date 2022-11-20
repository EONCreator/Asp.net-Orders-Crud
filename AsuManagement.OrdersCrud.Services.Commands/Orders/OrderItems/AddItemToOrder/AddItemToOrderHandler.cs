﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AsuManagement.OrdersCrud.Domain.Interfaces;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

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
                return AddItemToOrderOutput.Failure("Заказ не найден");

            if (request.Name == order.Number)
                return AddItemToOrderOutput.Failure("Название элемента не может равняться номеру заказа");

            var orderItem = new OrderItem(request.Name, request.Quantity, request.Unit);
            order.AddOrderItem(orderItem);

            await unitOfWork.Commit();

            return AddItemToOrderOutput.Success(orderItem.Id);
        }
    }
}