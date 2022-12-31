using Moq;
using Reservation.Repositories.Abstractions;

namespace Reservation.Tests;

public class RepositoryTests
{
    [Fact]
    public void ShouldGetOneCustomer_AfterAddingOne()
    {
        var customerRepository = new Mock<ICustomerRepository>().Object;
    }
}