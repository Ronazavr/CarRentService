using CarRentService.DataAccess.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Rental
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }
    public int CarId { get; set; }
    public int? UserSubscriptionId { get; set; } // Теперь ссылается на UserSubscription.Id

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal TotalCost { get; set; }

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "active";

    // Навигационные свойства
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;

    [ForeignKey(nameof(CarId))]
    public Car Car { get; set; } = null!;

    [ForeignKey(nameof(UserSubscriptionId))]
    public UserSubscription? UserSubscription { get; set; } // Может быть null
}