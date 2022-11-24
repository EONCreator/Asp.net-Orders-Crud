using MediatR;
using FluentValidation;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;

namespace AsuManagement.OrdersCrud.Services.Commands.Orders.AddItemToOrder
{
    public class AddItemToOrderCommand : IRequest<EntityIdOutput>
    {
        public int OrderId { get; }
        public string Name { get; }
        public decimal Quantity { get; }
        public string Unit { get; }

        public AddItemToOrderCommand(int orderId, string name, decimal quantity, string unit)
        {
            OrderId = orderId;
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }
    }

    public class AddItemToOrderCommandValidator : AbstractValidator<AddItemToOrderCommand>
    {
        public AddItemToOrderCommandValidator()
        {
            RuleFor(o => o.OrderId).NotNull();
            RuleFor(o => o.Name).NotNull();
            RuleFor(o => o.Quantity).NotNull();
            RuleFor(o => o.Unit).NotNull();
        }
    }
}
