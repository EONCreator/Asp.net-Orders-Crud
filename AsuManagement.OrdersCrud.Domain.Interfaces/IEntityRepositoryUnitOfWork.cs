namespace AsuManagement.OrdersCrud.Domain.Interfaces
{
    public interface IEntityRepositoryUnitOfWork : IAsyncDisposable
    {
        Task Commit();
        Task Rollback();
    }
}
