namespace Reservation.Domain;

public abstract class BaseEntity : IId, ISoftDelete
{
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTimeOffset.Now;
    }
    public Guid Id { get; set; }
    public DateTimeOffset CreatedAt { get;init; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
}