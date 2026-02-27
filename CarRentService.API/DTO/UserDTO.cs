// CarRentService.API/DTO/UserDto.cs
namespace CarRentService.API.DTO;

public class UserDto
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; }
    public string Role { get; set; } = string.Empty;
    public int Rating { get; set; }
    public bool IsBlocked { get; set; }
    public int? LoyaltyProgramId { get; set; }
    // Можно добавить название программы лояльности, если нужно
}