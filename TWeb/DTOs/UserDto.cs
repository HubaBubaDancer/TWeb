using TWeb.Models;

namespace TWeb.DTOs;

public class UserDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? LicenseNumber { get; set; }
    public string? IdCardNumber { get; set; }
    public RentHistoryDto RentHistory { get; set; }
}