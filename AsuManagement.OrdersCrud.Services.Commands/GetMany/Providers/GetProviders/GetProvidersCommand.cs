using AsuManagement.OrdersCrud.Domain.Core.Entities;
using MediatR;

namespace AsuManagement.OrdersCrud.Services.Commands.Providers
{
    public class GetProvidersCommand : IRequest<List<Provider>>
    {
        public string? Numbers { get; }

        public GetProvidersCommand(string numbers) {
            Numbers = numbers;
        }
    }
}