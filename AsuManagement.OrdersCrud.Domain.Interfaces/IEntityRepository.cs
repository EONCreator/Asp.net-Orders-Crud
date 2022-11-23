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
