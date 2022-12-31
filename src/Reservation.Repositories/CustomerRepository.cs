using Microsoft.EntityFrameworkCore;
using Reservation.Domain;
using Reservation.Repositories.Abstractions;

namespace Reservation.Repositories;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    protected CustomerRepository(ReservationDbContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<Customer?> GetByEmail(string mail)
    {
        return await DatabaseContext.Customers.SingleOrDefaultAsync(x => x.Email == mail);
    }
}