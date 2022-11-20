using AsuManagement.OrdersCrud.Domain.Interfaces;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AsuManagement.OrdersCrud.Domain.Core;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using AsuManagement.OrdersCrud.Services.Commands;
using System.Linq;

namespace AsuManagement.OrdersCrud.Domain.Interfaces.Results
{
    public class GetProvidersHandler : GetManyHandler<GetProvidersCommand, Provider>
    {
        public GetProvidersHandler(IEntityRepository repository) : base(repository) {
        }

        public override async Task<List<Provider>> Get(GetProvidersCommand request)
        => await Repository.Entity<Provider>().ToListAsync();
    }
}