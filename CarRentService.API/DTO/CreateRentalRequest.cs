// CarRentService.API/DTO/CreateRentalRequest.cs
using System.ComponentModel.DataAnnotations;

namespace CarRentService.API.DTO;

public class CreateRentalRequest
{
    [Required]
    public int CarId { get; set; }

    public int? UserSubscriptionId { get; set; } // опционально

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }
}