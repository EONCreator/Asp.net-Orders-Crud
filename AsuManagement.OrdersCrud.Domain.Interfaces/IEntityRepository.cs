using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AsuManagement.OrdersCrud.Domain.Interfaces
{
    public interface IEntityRepository
    {
        DbSet<TEntity> Entity<TEntity>() where TEntity : class;

        IEntityRepositoryUnitOfWork CreateUnitOfWork();
        Task SaveChanges();
    }
}
