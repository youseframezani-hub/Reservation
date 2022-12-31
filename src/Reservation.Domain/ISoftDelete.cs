namespace Reservation.Domain;

public interface ISoftDelete
{
    public DateTimeOffset? DeletedAt { get; set; }
    public bool IsDeleted => DeletedAt.HasValue;
}