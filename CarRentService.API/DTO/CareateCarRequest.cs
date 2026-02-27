// CarRentService.API/DTO/CreateCarRequest.cs
using System.ComponentModel.DataAnnotations;

namespace CarRentService.API.DTO;

public class CreateCarRequest
{
    [Required]
    [MaxLength(100)]
    public string Brand { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Model { get; set; } = string.Empty;

    public int Year { get; set; }

    [Required]
    [MaxLength(20)]
    public string LicensePlate { get; set; } = string.Empty;

    [Required]
    [MaxLength(17)]
    public string VIN { get; set; } = string.Empty;

    [Range(0, double.MaxValue)]
    public decimal DailyRate { get; set; }

    public bool IsExclusive { get; set; }

    public string? DetailsJson { get; set; }
    public string? PhotoUrls { get; set; }
}