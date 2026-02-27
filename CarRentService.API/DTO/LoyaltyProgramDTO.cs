// CarRentService.API/DTO/LoyaltyProgramDto.cs
namespace CarRentService.API.DTO;

public class LoyaltyProgramDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int MinRatingRequired { get; set; }
    public decimal DiscountPercent { get; set; }
}