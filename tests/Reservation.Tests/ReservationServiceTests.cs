using Reservation.Core;

namespace Reservation.Tests;

public class ReservationServiceTests
{
    [Fact]
    public void ServiceIsInactiveInOrganization_IsActiveShouldBeFalse()
    {
        var service = Service.Create("service_01",null,Currency.Default,TimeSpan.FromHours(1),1,1,false,false);
        Assert.False(service.IsActive());
        
    }
}