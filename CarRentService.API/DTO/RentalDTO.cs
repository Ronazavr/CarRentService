// CarRentService.API/DTO/RentalDto.cs
namespace CarRentService.API.DTO;

public class RentalDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty; // для удобства
    public int CarId { get; set; }
    public string CarInfo { get; set; } = string.Empty; // например, "Toyota Camry"
    public int? UserSubscriptionId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public decimal TotalCost { get; set; }
    public string Status { get; set; } = string.Empty;
}