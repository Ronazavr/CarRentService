// CarRentService.API/DTO/UserSubscriptionDto.cs
namespace CarRentService.API.DTO;

public class UserSubscriptionDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int SubscriptionId { get; set; }
    public string SubscriptionName { get; set; } = string.Empty; // для удобства
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Status { get; set; } = string.Empty;
}