// CarRentService.API/DTO/LoginRequest.cs
using System.ComponentModel.DataAnnotations;

namespace CarRentService.API.DTO;

public class LoginRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}