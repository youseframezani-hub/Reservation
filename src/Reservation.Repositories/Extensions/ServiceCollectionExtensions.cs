using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Reservation.Repositories.Abstractions;

namespace Reservation.Repositories.Extensions;

public static class ServiceCollectionExtensions
{
   public static IServiceCollection ConfigureRepository(this IServiceCollection services)
   {
      services.AddScoped<ICustomerRepository, CustomerRepository>();
      services.AddScoped<ISupplierRepository, SupplierRepository>();
      services.AddDbContext<ReservationDbContext>(conf=>
         conf.UseInMemoryDatabase("Reservation"));
      return services;
   }
}