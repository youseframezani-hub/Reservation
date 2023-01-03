using Microsoft.EntityFrameworkCore;
using Moq;
using Reservation.Domain;
using Reservation.Repositories;
using Reservation.Repositories.Abstractions;

namespace Reservation.Tests;

public class RepositoryTests
{
    [Fact]
    public void ShouldGetOneCustomer_AfterAddingOne()
    {
        var builder = new DbContextOptionsBuilder<ReservationDbContext>();
        var options = builder.Options;
        using (var context = new ReservationDbContext(options))
        {
            var customer = new Customer()
            {
                Email = "test@test.com",
                Name = "Test"
            };
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        using (var getContext = new ReservationDbContext(options))
        {
            var customers = getContext.Customers.ToList();
            Assert.Single(customers);
        }
    }
}