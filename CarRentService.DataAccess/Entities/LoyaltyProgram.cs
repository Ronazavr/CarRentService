using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentService.DataAccess.Entities;

/// <summary>
/// Программа лояльности (уровни)
/// </summary>
public class LoyaltyProgram
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    /// <summary>
    /// Минимальный рейтинг для вступления в программу
    /// </summary>
    public int MinRatingRequired { get; set; }

    /// <summary>
    /// Скидка в процентах (например, 5.00 = 5%)
    /// </summary>
    [Column(TypeName = "decimal(5,2)")]
    public decimal DiscountPercent { get; set; }

    // Навигационные свойства
    public ICollection<User> Users { get; set; }
}