using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;

namespace AsuManagement.OrdersCrud.Domain.Interfaces.Queires
{
    public class GetManyQuery<TViewModel> : IRequest<GetManyQueryResponse<TViewModel>>
    {
        public GetManyQuery()
        {
            
        }
    }
}
