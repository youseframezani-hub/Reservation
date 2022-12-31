using Reservation.Domain;
using Reservation.Repositories.Abstractions;

namespace Reservation.Repositories;

public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
{
    protected SupplierRepository(ReservationDbContext databaseContext) : base(databaseContext)
    {
    }
}