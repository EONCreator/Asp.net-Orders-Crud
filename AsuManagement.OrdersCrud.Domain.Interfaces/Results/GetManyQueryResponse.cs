using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsuManagement.OrdersCrud.Domain.Interfaces.Results
{
    public class GetManyQueryResponse<TViewModel>
    {
        public List<TViewModel> Items { get; }
        public int TotalCount { get; }

        public GetManyQueryResponse(List<TViewModel> items, int totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }
    }
}
