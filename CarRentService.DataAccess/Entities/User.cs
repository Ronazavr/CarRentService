using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentService.DataAccess.Entities;

/// <summary>
/// Пользователь системы
/// </summary>
public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MaxLength(20)]
    [Phone]
    public string Phone { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    public DateTime RegistrationDate { get; set; }

    /// <summary>
    /// Роль: user, admin, moderator
    /// </summary>
    [Required]
    [MaxLength(20)]
    public string Role { get; set; } = "user";

    /// <summary>
    /// Рейтинг водителя (начисляется за аккуратное вождение)
    /// </summary>
    public int Rating { get; set; }

    /// <summary>
    /// Заблокирован ли пользователь
    /// </summary>
    public bool IsBlocked { get; set; }

    // Внешний ключ к программе лояльности (может быть NULL)
    public int? LoyaltyProgramId { get; set; }

    // Навигационные свойства
    [ForeignKey(nameof(LoyaltyProgramId))]
    public LoyaltyProgram LoyaltyProgram { get; set; }

    public ICollection<UserSubscription> UserSubscriptions { get; set; }
    public ICollection<Rental> Rentals { get; set; }
}