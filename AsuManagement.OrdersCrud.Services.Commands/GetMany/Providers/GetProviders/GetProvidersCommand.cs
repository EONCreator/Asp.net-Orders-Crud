using MediatR;

namespace AsuManagement.OrdersCrud.Services.Commands.Providers
{
    public class GetProvidersCommand : IRequest<GetProvidersOutput>
    {
        public string? Numbers { get; }

        public GetProvidersCommand(string numbers) {
            Numbers = numbers;
        }
    }
}