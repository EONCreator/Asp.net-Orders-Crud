using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsuManagement.OrdersCrud.Domain.Interfaces
{
    public interface IEntityRepositoryUnitOfWork : IAsyncDisposable
    {
        Task Commit();
        Task Rollback();
    }
}
