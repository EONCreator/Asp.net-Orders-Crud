using MediatR;
using FluentValidation;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;

namespace AsuManagement.OrdersCrud.Services.Commands.Orders.CreateOrder
{
    public class CreateOrderCommand : IRequest<EntityIdOutput>
    {
        public string Number { get; }
        public DateTime Date { get; }
        public int ProviderId { get; }

        public CreateOrderCommand(string number, DateTime date, int providerId)
        {
            Number = number;
            Date = date;
            ProviderId = providerId;
        }
    }

    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(o => o.Number).NotNull();
            RuleFor(o => o.Date).NotNull();
            RuleFor(o => o.ProviderId).NotNull();
        }
    }
}
