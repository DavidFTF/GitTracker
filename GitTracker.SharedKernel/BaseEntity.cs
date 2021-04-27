namespace GitTracker.SharedKernel
{
    public abstract class BaseEntity<TId> : IEntity<TId>
    {
        public TId Id { get; set; }
    }
}