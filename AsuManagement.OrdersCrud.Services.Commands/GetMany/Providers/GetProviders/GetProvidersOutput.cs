using AsuManagement.OrdersCrud.Domain.Core.Entities;

namespace AsuManagement.OrdersCrud.Services.Commands.Providers
{
    public class GetProvidersOutput
    {
        public List<Provider> Providers { get; }
        public GetProvidersOutput(List<Provider> providers)
        {
            Providers = providers;
        }
    }
}
