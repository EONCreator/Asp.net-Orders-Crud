using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsuManagement.OrdersCrud.Domain.Interfaces.Results
{
    public class GetOneQueryResponse<TViewModel>
    {
        public TViewModel? Result { get; }

        public GetOneQueryResponse(TViewModel? result)
        {
            Result = result;
        }
    }
}
