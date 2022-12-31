using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace Reservation.Domain;

public class Customer : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
}