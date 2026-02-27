using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentService.DataAccess.Entities;

/// <summary>
/// Тариф/подписка, доступная пользователям
/// </summary>
public class Subscription
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }

    /// <summary>
    /// Приоритет при доступе к редким автомобилям (чем выше, тем больше привилегий)
    /// </summary>
    public int PriorityLevel { get; set; }

    // Навигационные свойства
    public ICollection<UserSubscription> UserSubscriptions { get; set; }
}