using Microsoft.AspNetCore.Identity;

namespace Back.DTOs;

public record PostPolyclinicDTO
{
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public int RegistrationOfficeId { get; set; }
    public int DistinctId { get; set; }
}