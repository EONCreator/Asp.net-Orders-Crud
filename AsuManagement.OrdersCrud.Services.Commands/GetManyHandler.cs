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

        protected IQueryable<TEntity> Filter(IQueryable<TEntity> filteredObjects, Expression<Func<TEntity, bool>> predicate) 
        {
            var property = (predicate.Body as BinaryExpression).Right;
            var value = ((ConstantExpression)property).Value;

            if (value == null)
                return filteredObjects;

            if (value.ToString().Length == 0)
                return filteredObjects;

            return filteredObjects.Where(predicate);
        }

        public async Task<GetManyQueryResponse<TEntity>> Handle(TCommand request, CancellationToken cancellationToken){
            var result = await Get(request);
            return new GetManyQueryResponse<TEntity>(result, result.Count);
        }

        public abstract Task<List<TEntity>> Get(TCommand request);
    }
}