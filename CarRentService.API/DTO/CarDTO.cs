// CarRentService.API/DTO/CarDto.cs
namespace CarRentService.API.DTO;

public class CarDto
{
    public int Id { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string LicensePlate { get; set; } = string.Empty;
    public decimal DailyRate { get; set; }
    public bool IsExclusive { get; set; }
    public string Status { get; set; } = string.Empty;
    // Опционально: можно добавить URL фотографий, если нужно
    public string? PhotoUrls { get; set; }
}