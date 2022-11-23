using System.Linq.Expressions;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using AsuManagement.OrdersCrud.Domain.Interfaces;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AsuManagement.OrdersCrud.Services.Commands
{
    public abstract class GetManyHandler<TCommand, TEntity> 
        : IRequestHandler<TCommand, GetManyQueryResponse<TEntity>>
        where TEntity : class
        where TCommand : GetManyCommand<TEntity>
    {
        protected readonly IEntityRepository Repository;

        public GetManyHandler(IEntityRepository repository)
        {
            Repository = repository;
        }

        public async Task<GetManyQueryResponse<TEntity>> Handle(TCommand request, CancellationToken cancellationToken){
            var result = await Get(request);
            return new GetManyQueryResponse<TEntity>(result, result.Count);
        }

        public abstract Task<List<TEntity>> Get(TCommand request);
    }
}