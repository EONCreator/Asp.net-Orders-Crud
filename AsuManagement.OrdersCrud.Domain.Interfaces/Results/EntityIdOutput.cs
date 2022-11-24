namespace AsuManagement.OrdersCrud.Domain.Interfaces.Results
{
    public class EntityIdOutput : SucceededResult
    {
        public int? Id { get; }

        public static EntityIdOutput Success(int? Id) => new(true, Id);
        public static EntityIdOutput Failure(string error) => new(false, null, error);

        public EntityIdOutput(bool succeeded, int? id, string? error = null)
            : base(succeeded, error)
        {
            Id = id;
        }
    }
}
