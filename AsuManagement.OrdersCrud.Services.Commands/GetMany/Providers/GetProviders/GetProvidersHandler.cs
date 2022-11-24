using MediatR;
using Microsoft.EntityFrameworkCore;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using AsuManagement.OrdersCrud.Domain.Interfaces;

namespace AsuManagement.OrdersCrud.Services.Commands.Providers
{
    public class GetProvidersHandler : IRequestHandler<GetProvidersCommand, List<Provider>>
    {
        private readonly IEntityRepository _repository;

        public GetProvidersHandler(IEntityRepository repository) {
            _repository = repository;
        }

        public async Task<List<Provider>> Handle(GetProvidersCommand request, CancellationToken cancellationToken)
        => await _repository.Entity<Provider>().ToListAsync(cancellationToken);
    }
}