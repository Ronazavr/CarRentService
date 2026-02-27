using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentService.DataAccess.Entities;

public class UserSubscription
{
    [Key]
    public int Id { get; set; } // Новый суррогатный ключ

    public int UserId { get; set; }
    public int SubscriptionId { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "active";

    // Навигационные свойства
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;

    [ForeignKey(nameof(SubscriptionId))]
    public Subscription Subscription { get; set; } = null!;

    // Связь с арендами
    public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}