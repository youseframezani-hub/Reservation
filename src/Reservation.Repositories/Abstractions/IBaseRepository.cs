using Reservation.Domain;

namespace Reservation.Repositories.Abstractions;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task AddEntityAsync(T entity);
    Task UpdateEntityAsync(T entity);
    Task DeleteEntityAsync(Guid id);
    Task<T> GetEntityAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllAsync(IEnumerable<Guid> ids);
}