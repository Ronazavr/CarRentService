// CarRentService.API/DTO/CarMaintenanceDto.cs
namespace CarRentService.API.DTO;

public class CarMaintenanceDto
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string CarInfo { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Cost { get; set; }
}