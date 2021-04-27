namespace GitTracker.SharedKernel
{
    public interface IEntity<TId> : IEntity
    {
        TId Id { get; set; }
    }

    public interface IEntity
    {
    }
}