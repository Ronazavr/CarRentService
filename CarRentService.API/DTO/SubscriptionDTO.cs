// CarRentService.API/DTO/SubscriptionDto.cs
namespace CarRentService.API.DTO;

public class SubscriptionDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int PriorityLevel { get; set; }
}