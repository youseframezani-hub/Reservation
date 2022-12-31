using System.Drawing;
using Microsoft.EntityFrameworkCore;
using Reservation.Domain;

namespace Reservation.Repositories;

public class ReservationDbContext : DbContext
{
    public ReservationDbContext(DbContextOptions<ReservationDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
}