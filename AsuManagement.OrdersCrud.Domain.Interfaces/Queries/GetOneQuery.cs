using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;

namespace AsuManagement.OrdersCrud.Domain.Interfaces.Queries
{
    public class GetOneQuery<TKey, TViewModel> : IRequest<GetOneQueryResponse<TViewModel>>
        where TViewModel : class
    {
        public TKey Id { get; }

        public GetOneQuery(TKey id)
        {
            Id = id;
        }
    }
}
