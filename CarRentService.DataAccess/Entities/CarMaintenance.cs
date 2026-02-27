using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentService.DataAccess.Entities;

/// <summary>
/// Запись о техническом обслуживании автомобиля
/// </summary>
public class CarMaintenance
{
    [Key]
    public int Id { get; set; }

    public int CarId { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Cost { get; set; }

    // Навигационные свойства
    [ForeignKey(nameof(CarId))]
    public Car Car { get; set; }
}