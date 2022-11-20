using System.Linq.Expressions;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using AsuManagement.OrdersCrud.Domain.Interfaces;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AsuManagement.OrdersCrud.Services.Commands
{
    public abstract class GetOneHandler<TCommand, TEntity> 
        : IRequestHandler<TCommand, GetOneQueryResponse<TEntity>>
        where TEntity : class
        where TCommand : GetOneCommand<TEntity>
    {
        protected readonly IEntityRepository Repository;

        public GetOneHandler(IEntityRepository repository)
        {
            Repository = repository;
        }

        public async Task<GetOneQueryResponse<TEntity>> Handle(TCommand request, CancellationToken cancellationToken){
            var result = await Get(request);
            return new GetOneQueryResponse<TEntity>(result);
        }

        public abstract Task<TEntity> Get(TCommand request);
    }
}