namespace AsuManagement.OrdersCrud.Domain.Interfaces
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }
}