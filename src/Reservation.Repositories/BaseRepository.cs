using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;
using Reservation.Domain;
using Reservation.Repositories.Abstractions;

namespace Reservation.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly ReservationDbContext DatabaseContext;

    protected BaseRepository(ReservationDbContext databaseContext)
    {
        DatabaseContext = databaseContext;
    }

    public async Task AddEntityAsync(T entity)
    {
        await DatabaseContext.Set<T>().AddAsync(entity);
        await DatabaseContext.SaveChangesAsync();
    }

    public async Task UpdateEntityAsync(T entity)
    {
        entity.UpdatedAt = DateTimeOffset.Now;
        DatabaseContext.Set<T>().Update(entity);

        await DatabaseContext.SaveChangesAsync();
    }

    public async Task DeleteEntityAsync(Guid id)
    {
        var entity = await GetEntityAsync(id);
        entity.DeletedAt = DateTimeOffset.Now;
        await UpdateEntityAsync(entity);
    }

    public async Task<T> GetEntityAsync(Guid id)
    {
        return await DatabaseContext.Set<T>().SingleAsync(x => x.Id == id);
    }


    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DatabaseContext.Set<T>().ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(IEnumerable<Guid> ids)
    {
        if (!ids.Any()) 
            return await GetAllAsync();
        return await DatabaseContext.Set<T>().Where(e => ids.Contains(e.Id)).ToListAsync();
    }
}