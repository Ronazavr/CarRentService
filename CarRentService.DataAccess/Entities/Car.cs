using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentService.DataAccess.Entities;

public class Car
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Brand { get; set; }

    [Required]
    [MaxLength(100)]
    public string Model { get; set; }

    public int Year { get; set; }

    [Required]
    [MaxLength(20)]
    public string LicensePlate { get; set; }

    [Required]
    [MaxLength(17)]
    public string VIN { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal DailyRate { get; set; }

    [Required]
    public string Status { get; set; } // available, rented, maintenance

    public bool IsExclusive { get; set; }

    public string? DetailsJson { get; set; } // для хранения характеристик в JSON

    public string? PhotoUrls { get; set; } // можно хранить как JSON-массив строк

    // Навигационные свойства
    public ICollection<Rental> Rentals { get; set; }
    public ICollection<CarMaintenance> Maintenances { get; set; }
}