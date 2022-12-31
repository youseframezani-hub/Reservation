using Reservation.Domain;

namespace Reservation.Repositories.Abstractions;

public interface ICustomerRepository : IBaseRepository<Customer>
{
    Task<Customer?> GetByEmail(string name);
}